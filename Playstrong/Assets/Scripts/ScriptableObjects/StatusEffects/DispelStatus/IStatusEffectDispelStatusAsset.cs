using System.Collections.Generic;
using Interfaces;
using Logic;

namespace ScriptableObjects.StatusEffects.Instance
{
    public interface IStatusEffectDispelStatusAsset
    {
        //Option 1
        IHeroStatusEffect AddToDispelList(IHeroStatusEffect statusEffect);

        //Option 2 (favored)
        void UpdateDispelList(List<IHeroStatusEffect> dispelList, IHeroStatusEffect statusEffect);

        void DispelStatusEffect(IHeroStatusEffect existingStatusEffect, IHero targetHero);
    }
}