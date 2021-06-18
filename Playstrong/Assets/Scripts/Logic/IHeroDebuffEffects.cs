using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace Logic
{
    public interface IHeroDebuffEffects
    {
        List<IHeroStatusEffect> HeroDebuffs { get; }

        List<Object> HeroDebuffObjects { get; }
    }
}