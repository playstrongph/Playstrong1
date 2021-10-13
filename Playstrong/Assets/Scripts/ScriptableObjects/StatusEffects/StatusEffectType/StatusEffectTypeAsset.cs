using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
   
    public class StatusEffectTypeAsset : ScriptableObject, IStatusEffectType
    {
        public virtual void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            
        }

        public virtual void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            
        }

        public virtual void IncreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
            //var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            existingStatusEffect.IncreaseStatusEffectCounters.IncreaseCounters(counters);
        }
        
        public virtual void DecreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            existingStatusEffect.DecreaseStatusEffectCounters.DecreaseCounters(counters,coroutineTreesAsset);
        }
        
        public virtual void SetCountersValue(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            existingStatusEffect.SetStatusEffectCounters.SetCounters(counters,coroutineTreesAsset);
        }
        
        public virtual void DispelStatusEffect(IHeroStatusEffect existingStatusEffect, IHero targetHero)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            existingStatusEffect.RemoveStatusEffect.RemoveEffect(targetHero);
        }


    }
}
