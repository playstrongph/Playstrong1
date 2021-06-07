using System.Collections.Generic;
using ScriptableObjects.StatusEffects;

namespace Logic
{
    public interface IHeroDebuffEffects
    {
        List<IDebuffEffect> HeroDebuffs { get; }
    }
}