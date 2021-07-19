
using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "PassiveSkill", menuName = "SO's/Skill Type/Passive Skill")]
    public class PassiveSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = false;
        }
        
        public override void ReduceSkillCd(ISkill skill, int counter)
        {
           //Do nothing for Passive Skills
        }
        
        public override void ResetSkillCd(ISkill skill)
        {
            //Do nothing for Passive Skills
        }
    }
}
