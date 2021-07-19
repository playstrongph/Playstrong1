using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums;
using UnityEngine;

namespace Logic
{
    public class ReduceSkillCooldown : MonoBehaviour, IReduceSkillCooldown
    {
        private ISkillLogic _skillLogic;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }


        public IEnumerator ChangeCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            ReduceCooldown(counter);
            
            logicTree.EndSequence();
            yield return null;
            
        }

        private void ReduceCooldown(int counter)
        {
            var skillAttributes = _skillLogic.SkillAttributes;     
            var skillCd = skillAttributes.Cooldown;

            skillCd -= counter;
            if (skillCd < 0) skillCd = 0;

            skillAttributes.Cooldown = skillCd;
            _skillLogic.SkillReadiness.SetStatus(skillCd);

            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(VisualReduceCdAction(skillCd));
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
