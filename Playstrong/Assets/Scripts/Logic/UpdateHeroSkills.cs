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
            skill.SkillLogic.SkillAttributes.SkillType.ReduceSkillCd(skill, skillCdCounter);
            
            var logicTree = _skillsPanel.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;

        }




    }
}
