using Logic;
using Visual;

namespace ScriptableObjects.Enums.SkillType
{
    public interface IActiveSkillAsset
    {
        void UseActiveSkill(ITargetSkill targetSkill, ITargetHero thisHero, ITargetHero targetHero);
    }
}