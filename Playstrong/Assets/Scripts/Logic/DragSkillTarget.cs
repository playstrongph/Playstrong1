using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;
using Visual;

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
            var logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;
            
            _useHeroSkill = NoAction;
            
            logicTree.AddCurrent(GetValidTargets());
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
            var logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SetSkillTarget());
            logicTree.AddCurrent(UseSkillOnTarget());
        }
        
        private IEnumerator SetSkillTarget()
        {
            var logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;
            
            SetTarget();

            yield return null;
            logicTree.EndSequence();

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
            var logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;
            
            _useHeroSkill();

            yield return null;
            logicTree.EndSequence();

        }


        private IEnumerator GetValidTargets()
        {
            var logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;
            var getSkillTargets = _targetSkill.GetSkillTargets;

            _validTargets = getSkillTargets.GetValidTargets();
            
            yield return null;
            logicTree.EndSequence();
        }
        
        

        private void UseHeroSkill()
        {
            var logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;
            var turnController = _targetSkill.Skill.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            
            
            //TODO: Execute Skill Effect (IEnum)
            logicTree.AddCurrent(ApplySkillEffect());
            
            logicTree.AddCurrent(_targetSkill.Skill.SkillLogic.ResetSkillCooldown.ResetCd()); 

            //this is already a IEnumerator
            turnController.EndTurn();

        }

        private IEnumerator ApplySkillEffect()
        {
            _thisHero = _targetSkill.Skill.Hero.TargetHero;
            
            var logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;
            
            _targetSkill.Skill.SkillLogic.SkillAttributes.SkillEffect.UseSkillEffect(_thisHero.Hero, _targetHero.Hero);
            
            
            yield return null;
            logicTree.EndSequence();
            
        }
        



        private void NoAction() { }

    }
}
