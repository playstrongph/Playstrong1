using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using ScriptableObjects.Enums.SkillType;
using UnityEngine;
using Visual;
using Debug = System.Diagnostics.Debug;

namespace Logic
{
    public class DragSkillTarget : MonoBehaviour, IDragSkillTarget
    {
        private ITargetSkill _targetSkill;
        
        private ITargetHero _thisHero;
        private ITargetHero _targetHero;

        private Action _skillTargetHero;
        private Action _useHeroSkill;

        private List<IHero> _validTargets = new List<IHero>();

        private IEndHeroTurn _endHeroTurn;

        private ICoroutineTree _logicTree;
        

        private void Awake()
        {
            _targetSkill = GetComponent<ITargetSkill>();
            _skillTargetHero = NoAction;
        }

        private void OnMouseUp()
        {
            _skillTargetHero();
        }

        private void OnMouseDown()
        {
            _logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;
            
            _useHeroSkill = NoAction;
            
            _logicTree.AddCurrent(GetValidTargets());
        }

        public void EnableDragSkillTarget()
        {
            _skillTargetHero = SkillTargetHero;
        }

        public void DisableDragSkillTarget()
        {
            _skillTargetHero = NoAction;
        }

        private void SkillTargetHero()
        {
           
            _logicTree.AddCurrent(SetSkillTarget());
            _logicTree.AddCurrent(UseSkillOnTarget());
        }
        
        private IEnumerator SetSkillTarget()
        {
            SetTarget();
            
            _logicTree.EndSequence();
            yield return null;

        }

        private void SetTarget()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            var hits = Physics.RaycastAll(ray);
            foreach (var hit in hits)
            {
                if (hit.transform.GetComponent<ITargetHero>() != null)
                {
                    var targetHero = hit.transform.GetComponent<ITargetHero>();

                    if (_validTargets.Contains(targetHero.Hero))
                    {
                        _targetHero = targetHero;
                        _useHeroSkill = UseHeroSkill;

                    }
                }
            }
            
        }

        private IEnumerator UseSkillOnTarget()
        {
           _useHeroSkill();
           
           _logicTree.EndSequence();
            yield return null;

        }


        private IEnumerator GetValidTargets()
        {
           
            var getSkillTargets = _targetSkill.GetSkillTargets;

            _validTargets = getSkillTargets.GetValidTargets();
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        

        private void UseHeroSkill()
        {
            
            var turnController = _targetSkill.Skill.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            
            
            
            _logicTree.AddCurrent(ApplySkillEffect());
            
            _logicTree.AddCurrent(_targetSkill.Skill.SkillLogic.ResetSkillCooldown.ResetCd()); 

            //Calls an Ienumerator
            turnController.EndTurn();

        }

        private IEnumerator ApplySkillEffect()
        {
            _thisHero = _targetSkill.Skill.Hero.TargetHero;
            
            //_targetSkill.Skill.SkillLogic.SkillAttributes.SkillEffect.UseSkillEffect(_thisHero.Hero, _targetHero.Hero);

            var activeSkill = _targetSkill.Skill.SkillLogic.SkillAttributes.SkillType;
            
            Debug.Assert(activeSkill != null, nameof(activeSkill) + " != null");
            
            activeSkill.UseActiveSkill(_targetSkill, _thisHero.Hero, _targetHero.Hero);
            
            _logicTree.EndSequence();
            yield return null;
            
        }
        



        private void NoAction() { }

    }
}
