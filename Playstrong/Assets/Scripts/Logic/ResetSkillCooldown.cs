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

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }


        public IEnumerator ChangeCooldown()
        {
           var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

           ResetCdAction();
            
            logicTree.EndSequence();
            yield return null;
        }

        private void ResetCdAction()
        {
            var skillAttributes = _skillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillAttributes.Cooldown = maxSkillCd;  
            _skillLogic.SkillReadiness.SetStatus(maxSkillCd);

            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(VisualReduceCdAction(maxSkillCd));
        }

        private IEnumerator VisualReduceCdAction(int skillCd)
        {
             var skillVisual = _skillLogic.Skill.SkillVisual;
             var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;

             skillVisual.SkillCooldownVisual.UpdateCooldown(skillCd);

             visualTree.EndSequence();
             yield return null;
            
        }

      


    }
}
