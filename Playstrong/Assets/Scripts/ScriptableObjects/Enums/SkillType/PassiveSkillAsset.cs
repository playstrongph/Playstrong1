
using Interfaces;
using Logic;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "Passive Skill", menuName = "SO's/Scriptable Enums/Passive Skill")]
    public class PassiveSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = false;
        }
    }
}
