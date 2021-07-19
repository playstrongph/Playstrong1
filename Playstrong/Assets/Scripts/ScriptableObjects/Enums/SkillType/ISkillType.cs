using Interfaces;
using Logic;
using References;
using TMPro;

namespace ScriptableObjects.Enums.SkillType
{
    public interface ISkillType
    {
        //int SkillCdIndex { get; }
        void SkillCooldownDisplay(TextMeshProUGUI cooldown);

        void ReduceSkillCd(ISkill skill, int counter);

        void ResetSkillCd(ISkill skill);

    }
}