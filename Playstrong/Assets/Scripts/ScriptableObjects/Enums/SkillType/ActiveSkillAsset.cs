using Interfaces;
using Logic;
using TMPro;
using UnityEngine;
using Visual;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "ActiveSkill", menuName = "SO's/Skill Type/Active Skill")]
    public class ActiveSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = true;
        }

    }
}
