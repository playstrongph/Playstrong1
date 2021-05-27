using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums
{
    public interface ISkillType
    {
        int SkillCdIndex { get; }

        void SkillCooldownDisplay(TextMeshProUGUI cooldown);

    }
}