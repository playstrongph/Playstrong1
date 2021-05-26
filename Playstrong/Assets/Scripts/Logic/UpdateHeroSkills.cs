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
        private IHeroSkillsList _heroSkillsList;
        private List<ISkill> _skills = new List<ISkill>();
        private int _skillCdCounter = 1;

        private ICoroutineTree _logicTree;

        private void Awake()
        {
            _heroSkillsList = GetComponent<IHeroSkillsList>();
        }

        private void Start()
        {
            _logicTree = _heroSkillsList.CoroutineTreesAsset.MainLogicTree;
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
            
            foreach (var skillObject in _heroSkillsList.SkillList)
            {
                var skill = skillObject.GetComponent<ISkill>();
                _skills.Add(skill);
            }
        }
        
        
    }
}
