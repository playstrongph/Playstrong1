using System.Collections.Generic;
using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    [CreateAssetMenu(fileName = "ChangeableCounters", menuName = "SO's/Status Effects/ChangeCounters/ChangeableCounters")]
    public class StatusEffectChangeableCountersAsset : StatusEffectChangeCountersAsset
    {

        public override void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters)
        {
            heroStatusEffect.IncreaseStatusEffectCounters.IncreaseCounters(counters);
        }
        
        public override void DecreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters)
        {
            heroStatusEffect.DecreaseStatusEffectCounters.DecreaseCounters(counters);
        }
        
        //TEST
        public override void ReduceStatusEffectCounters(IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffect.ReduceStatusEffectCounters.ReduceCounters(heroStatusEffect.CoroutineTreesAsset);
        }
        
        

        public override void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect,int counters)
        {
            heroStatusEffect.SetStatusEffectCounters.SetCounters(counters);
        }
        
        public override void SetChangeableToTempNoDecrease(IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffect.UpdateStatusEffectChangeableCounters.SetToTempNoDecreaseCounters();
        }
    }
}
