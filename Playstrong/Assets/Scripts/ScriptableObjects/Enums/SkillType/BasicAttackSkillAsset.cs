﻿using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;
using Visual;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "BasicAttackSkill", menuName = "SO's/Skill Type/BasicAttackSkill")]
    public class BasicAttackSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = false;
        }

        public override void ReduceSkillCd(ISkill skill, int counter)
        {
            
        }
        
        public override void ResetSkillCd(ISkill skill)
        {
            
        }

    }
}
