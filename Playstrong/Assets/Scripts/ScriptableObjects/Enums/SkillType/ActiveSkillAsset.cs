using Interfaces;
using Logic;
using TMPro;
using UnityEngine;
using Visual;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "Active Skill", menuName = "SO's/Scriptable Enums/Active Skill")]
    public class ActiveSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = true;
        }

    }
}
