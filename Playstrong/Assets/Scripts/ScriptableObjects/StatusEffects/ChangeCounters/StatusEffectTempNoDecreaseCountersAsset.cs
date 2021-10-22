using System.Collections.Generic;
using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    [CreateAssetMenu(fileName = "TempNoDecrease", menuName = "SO's/Status Effects/ChangeCounters/TempNoDecrease")]
    public class StatusEffectTempNoDecreaseCountersAsset : StatusEffectChangeCountersAsset
    {
       
        
        public override void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters)
        {
            heroStatusEffect.IncreaseStatusEffectCounters.IncreaseCounters(counters);
        }
        
        public override void DecreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters)
        {
            //heroStatusEffect.DecreaseStatusEffectCounters.DecreaseCounters(counters);
            heroStatusEffect.UpdateStatusEffectChangeableCounters.SetToChangeableCounters();
        }

        public override void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect,int counters)
        {
            heroStatusEffect.SetStatusEffectCounters.SetCounters(counters);
        }
    }
}
