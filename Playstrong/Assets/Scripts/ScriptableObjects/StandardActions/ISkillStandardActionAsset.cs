using Interfaces;
using References;

namespace ScriptableObjects.StandardActions
{
    public interface ISkillStandardActionAsset
    {
        void SetSkillReference(ISkill skill);

        void SkillStartActionCoroutines(IHero thisHero, IHero targetHero);

        void SkillStartActionCoroutines(IHero targetHero);
    }
}