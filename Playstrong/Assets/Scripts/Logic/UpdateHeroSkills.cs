using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class UpdateHeroSkills : MonoBehaviour, IUpdateHeroSkills
    {
        private ISkillsPanel _skillsPanel;
        private int _skillCdCounter = 1;

        private ICoroutineTree _logicTree;

        private void Awake()
        {
            _skillsPanel = GetComponent<ISkillsPanel>();
        }

        private void Start()
        {
            _logicTree = _skillsPanel.CoroutineTreesAsset.MainLogicTree;
        }

        public IEnumerator UpdateSkills()
        {
            UpdateSkillCooldowns();

            _logicTree.EndSequence();
            yield return null;
        }

        private void UpdateSkillCooldowns()
        {
            foreach (var skillObject in _skillsPanel.SkillList)
            {
                var skill = skillObject.GetComponent<ISkill>();
                Debug.Log("Skill Name: " +skillObject.name);
                
               _logicTree.AddCurrent(skill.SkillLogic.ReduceSkillCooldown.ReduceCd(_skillCdCounter));
            }
        }

       
        
        
    }
}
