using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums;
using UnityEngine;

namespace Logic
{
    public class ResetSkillCooldown : MonoBehaviour, IResetSkillCooldown
    {
        private ISkillLogic _skillLogic;
        
        private List<Action> _skillCdAction = new List<Action>();
       
        /// <summary>
        /// Set to 0 for ActiveSkills
        /// Set to 1 for PassiveSkills
        /// </summary>
        private int _actionIndex = 0;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();

            _skillCdAction.Add(ResetCdAction);
            _skillCdAction.Add(DoNothing);
        }


        public IEnumerator ResetCd()
        {
           var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
           var skillType = _skillLogic.SkillAttributes.SkillType;
           
            _actionIndex = skillType.SkillCdIndex;
            
            _skillCdAction[_actionIndex]();
            
            logicTree.EndSequence();
            yield return null;
        }

        private void ResetCdAction()
        {
            var skillAttributes = _skillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillAttributes.Cooldown = maxSkillCd;  
          _skillLogic.UpdateSkillStatus.SetStatus(maxSkillCd);
          
          //TODO: SetSkill Status NotReady

           var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
           visualTree.AddCurrent(VisualReduceCdAction());
        }

        private IEnumerator VisualReduceCdAction()
        {
             var skillVisual = _skillLogic.Skill.SkillVisual;
             var maxSkillCd = _skillLogic.SkillAttributes.BaseCooldown;
             
             skillVisual.SkillCooldownVisual.UpdateCooldown(maxSkillCd);
             
             var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
             visualTree.EndSequence();
             yield return null;
            
        }

        private void DoNothing()
        {
            
        }


    }
}
