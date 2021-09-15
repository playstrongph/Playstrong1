using System.Collections.Generic;

namespace Logic
{
    public interface IHeroSkillBuffEffects
    {
        List<IHeroStatusEffect> HeroSkillBuffs { get; }
        void AddToList(IHeroStatusEffect buffEffect);
        void RemoveFromList(IHeroStatusEffect buffEffect);
    }
}