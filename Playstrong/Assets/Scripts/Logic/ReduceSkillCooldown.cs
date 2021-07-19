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

        private delegate void SkillCdAction(int counter);
        private List<SkillCdAction> _skillCdAction = new List<SkillCdAction>();
       
        /// <summary>
        /// Set to 0 for ActiveSkills
        /// Set to 1 for PassiveSkills
        /// </summary>
        private int _actionIndex = 0;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();

            _skillCdAction.Add(ReduceCooldown);
            _skillCdAction.Add(DoNothing);
        }


        public IEnumerator UpdateCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var skillType = _skillLogic.SkillAttributes.SkillType;
            
            _actionIndex = skillType.SkillCdIndex;
            _skillCdAction[_actionIndex](counter);
            
            
            
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

        private void DoNothing(int counter)
        {
            
        }


    }
}
