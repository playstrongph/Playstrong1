using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace Logic
{
    public class UpdateHeroSkills : MonoBehaviour, IUpdateHeroSkills
    {
        private ISkillsPanel _skillsPanel;
        
        [SerializeField]
        private int skillCdCounter = 1;

        

        private void Awake()
        {
            _skillsPanel = GetComponent<ISkillsPanel>();
        }

        
        public IEnumerator UpdateSkills()
        {
           
            var logicTree = _skillsPanel.CoroutineTreesAsset.MainLogicTree;
            
            UpdateSkillCooldown();

            logicTree.EndSequence();
            yield return null;
           
        }

        private void UpdateSkillCooldown()
        {
            foreach (var skillObject in _skillsPanel.SkillList)
            {
                 var skill = skillObject.GetComponent<ISkill>();
                 var logicTree = _skillsPanel.CoroutineTreesAsset.MainLogicTree;

                 logicTree.AddCurrent(ReduceSkillCooldown(skill, skillCdCounter));
            }
        }


        private IEnumerator ReduceSkillCooldown(ISkill skill, int value)
        {
            var logicTree = _skillsPanel.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Pass by SkillUseStatus - reducecd if status is NOT UsedLastTurn, otherwise set to NotUsingSkill
            //skill.SkillLogic.SkillAttributes.SkillType.ReduceSkillCd(skill, skillCdCounter);
            
            //TEST
            logicTree.AddCurrent(skill.SkillLogic.SkillAttributes.SkillUseStatus.StatusAction(skill, value));
            
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator UpdateSkillReadinessStatus()
        {
           
            var logicTree = _skillsPanel.CoroutineTreesAsset.MainLogicTree;
            
            UpdateSkillReadinessStatusAction();

            logicTree.EndSequence();
            yield return null;
           
        }
        
        private void UpdateSkillReadinessStatusAction()
        {
            foreach (var skillObject in _skillsPanel.SkillList)
            {
                var skill = skillObject.GetComponent<ISkill>();
                var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
                
                logicTree.AddCurrent(UpdateSkillReadinessBasedOnCooldown(skill));

                logicTree.AddCurrent(SkillReadinessStatusAction(skill));
            }
        }
        
        private IEnumerator SkillReadinessStatusAction(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            skill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(skill.SkillLogic);
            
            logicTree.EndSequence();
            yield return null;

        }
        
       
        private IEnumerator UpdateSkillReadinessBasedOnCooldown(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            skill.SkillLogic.SkillAttributes.SkillCooldownType.UpdateSkillReadinessStatus(skill);
            
            logicTree.EndSequence();
            yield return null;

        }




    }
}
