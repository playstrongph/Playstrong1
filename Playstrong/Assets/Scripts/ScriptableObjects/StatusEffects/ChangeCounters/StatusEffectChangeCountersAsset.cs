using System.Collections.Generic;
using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    public class StatusEffectChangeCountersAsset : ScriptableObject
    {
        [SerializeField] protected int statusEffectCounters;
        
        
        
        public virtual void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffect.IncreaseStatusEffectCounters.IncreaseCounters(statusEffectCounters);
        }
        
        
        

    }
}
