using TMPro;

namespace ScriptableObjects.Enums.SkillType
{
    public interface ISkillType
    {
        int SkillCdIndex { get; }

        void SkillCooldownDisplay(TextMeshProUGUI cooldown);

    }
}