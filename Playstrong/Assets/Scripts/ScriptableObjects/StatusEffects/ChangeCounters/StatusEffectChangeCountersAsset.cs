using System.Collections.Generic;
using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    public class StatusEffectChangeCountersAsset : ScriptableObject, IStatusEffectChangeCountersAsset
    {
        

        public virtual void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect, int counters)
        {
            //heroStatusEffect.IncreaseStatusEffectCounters.IncreaseCounters(statusEffectCounters);
        }
        
        public virtual void DecreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters)
        {
            //heroStatusEffect.DecreaseStatusEffectCounters.DecreaseCounters(statusEffectCounters);
        }

        public virtual void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect,int counters)
        {
            //heroStatusEffect.SetStatusEffectCounters.SetCounters(statusEffectCounters);
        }






    }
}
