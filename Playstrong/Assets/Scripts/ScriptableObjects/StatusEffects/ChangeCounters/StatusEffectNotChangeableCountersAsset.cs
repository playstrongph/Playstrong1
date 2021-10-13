using System.Collections.Generic;
using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    [CreateAssetMenu(fileName = "NotChangeableCounters", menuName = "SO's/Status Effects/ChangeCounters/NotChangeableCounters")]
    public class StatusEffectNotChangeableCountersAsset : StatusEffectChangeCountersAsset
    {
        
        public override void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters)
        {
          base.IncreaseStatusEffectCounters(heroStatusEffect,counters);
        }
        
        public override void DecreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters)
        {
          base.DecreaseStatusEffectCounters(heroStatusEffect,counters);
        }

        public override void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect,int counters)
        {
          base.SetStatusEffectCountersToValue(heroStatusEffect,counters);
        }
    }
}
