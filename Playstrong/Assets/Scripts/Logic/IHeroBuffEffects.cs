using System.Collections.Generic;
using ScriptableObjects.StatusEffects;

namespace Logic
{
    public interface IHeroBuffEffects
    {
        List<IBuffEffect> HeroBuffs { get; }
    }
}