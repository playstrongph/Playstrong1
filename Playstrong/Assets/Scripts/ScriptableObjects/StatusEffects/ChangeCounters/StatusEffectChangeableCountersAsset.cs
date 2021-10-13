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
        [SerializeField] private int statusEffectCounters;
        
        public override void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffect.IncreaseStatusEffectCounters.IncreaseCounters(statusEffectCounters);
        }
        
        public override void DecreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffect.DecreaseStatusEffectCounters.DecreaseCounters(statusEffectCounters);
        }

        public override void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffect.SetStatusEffectCounters.SetCounters(statusEffectCounters);
        }
    }
}
