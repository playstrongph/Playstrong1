using Interfaces;
using Logic;
using TMPro;

namespace ScriptableObjects.Enums.SkillType
{
    public interface ISkillType
    {
        int SkillCdIndex { get; }

        void SkillCooldownDisplay(TextMeshProUGUI cooldown);

        void UseActiveSkill(ITargetSkill targetSkill, IHero thisHero, IHero targetHero);

        void UsePassiveSkill(ITargetSkill targetSkill, IHero thisHero, IHero targetHero);

    }
}