using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace Logic
{
    public interface IHeroDebuffEffects
    {
        List<IHeroStatusEffect> HeroDebuffs { get; }

        void AddToList(IHeroStatusEffect debuffEffect);

        void RemoveFromList(IHeroStatusEffect debuffEffect);


    }
}