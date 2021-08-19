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
            
            _logicTree.AddCurrent(UseSkillEffect());

            //_logicTree.AddCurrent(_targetSkill.Skill.SkillLogic.ResetSkillCooldown.UpdateCooldown());
            _logicTree.AddCurrent(ResetSkillCooldown());

            _logicTree.AddCurrent(HeroEndTurn());

        }
        
        
        
        private IEnumerator UseSkillEffect()
        {
            _thisHero = _targetSkill.Skill.Hero.TargetHero;
            
            _targetSkill.Skill.SkillLogic.SkillEvents.DragSkillTarget(_thisHero.Hero, _targetHero.Hero);
            
            _logicTree.EndSequence();
            yield return null;
            
        }
        
        /// <summary>
        /// Resets skill cooldown to Maximum CD
        /// </summary>
        private IEnumerator ResetSkillCooldown()
        {
            var skill = _targetSkill.Skill;
            
            skill.SkillLogic.SkillAttributes.SkillType.ResetSkillCd(skill);

            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator HeroEndTurn()
        {
            var turnController = _targetSkill.Skill.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            turnController.EndTurn();
            _logicTree.EndSequence();
            yield return null;
        }

      
        



        private void NoAction() { }

    }
}
