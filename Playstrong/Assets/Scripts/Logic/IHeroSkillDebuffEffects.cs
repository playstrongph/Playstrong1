using System.Collections.Generic;

namespace Logic
{
    public interface IHeroSkillDebuffEffects
    {
        List<IHeroStatusEffect> HeroSkillDebuffs { get; }
        void AddToList(IHeroStatusEffect skillDebuffEffect);
        void RemoveFromList(IHeroStatusEffect skillDebuffEffect);
    }
}