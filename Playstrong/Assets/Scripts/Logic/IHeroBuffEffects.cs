using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace Logic
{
    public interface IHeroBuffEffects
    {
        List<IHeroStatusEffect> HeroBuffs { get; }

        List<Object> HeroBuffObjects { get; }
    }
}