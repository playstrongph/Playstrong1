﻿
using Interfaces;
using Logic;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "Passive Skill", menuName = "SO's/Scriptable Enums/Passive Skill")]
    public class PassiveSkillAsset : ScriptableObject, ISkillType
    {
        private ITargetSkill _targetSkill;

        [SerializeField] private int _skillCdIndex = 1;
        public int SkillCdIndex => _skillCdIndex;
        public void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = false;
        }

        
       




    }
}
