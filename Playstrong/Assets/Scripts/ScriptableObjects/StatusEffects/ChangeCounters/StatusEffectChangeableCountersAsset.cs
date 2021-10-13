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

        public override void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect,int counters)
        {
            heroStatusEffect.SetStatusEffectCounters.SetCounters(counters);
        }
    }
}
