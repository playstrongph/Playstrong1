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
        
        public override void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect)
        {
          base.IncreaseStatusEffectCounters(heroStatusEffect);
        }
        
        public override void DecreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect)
        {
          base.DecreaseStatusEffectCounters(heroStatusEffect);
        }

        public override void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect)
        {
          base.SetStatusEffectCountersToValue(heroStatusEffect);
        }
    }
}
