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
        private int _skillCdCounter = 1;

        

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

                 //TODO:  Make this pass by skill type
                 logicTree.AddCurrent(skill.SkillLogic.ReduceSkillCooldown.ReduceCd(_skillCdCounter));
            }
        }

        
        
        
    }
}
