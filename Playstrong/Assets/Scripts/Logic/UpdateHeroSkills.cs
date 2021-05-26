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
        private List<ISkill> _skills = new List<ISkill>();
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
            GetHeroSkills();
            UpdateSkillCooldowns();

            yield return null;
            _logicTree.EndSequence();
        }

        private void UpdateSkillCooldowns()
        {
            foreach (var skill in _skills)
            {
                _logicTree.AddCurrent(skill.SkillLogic.ReduceSkillCooldown.ReduceCd(_skillCdCounter));
            }
        }

        private void GetHeroSkills()
        {
            _skills.Clear();
            
            foreach (var skillObject in _skillsPanel.SkillList)
            {
                var skill = skillObject.GetComponent<ISkill>();
                _skills.Add(skill);
            }
        }
        
        
    }
}
