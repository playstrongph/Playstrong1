using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "FixedInstance", menuName = "SO's/Status Effects/Instance/Fixed Instance")]
    public class FixedInstance : StatusEffectInstance
    {
        private int _fixedValue = 1;
        
        /// <summary>
        /// Checks if there is an existing status effect on the hero
        /// Create a new one if there is none
        /// Update the status effect counter to a fixed value of one if it exists
        /// </summary>
        public override  void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            statusEffectCounters = _fixedValue;
            CheckExistingStatusEffects(hero, statusEffectAsset);
            
            if (ExistingStatusEffect != null)
                UpdateStatusEffect(ExistingStatusEffect,statusEffectCounters, hero);
            else  
            {
                NewStatusEffect = CreateStatusEffect(hero, statusEffectAsset, statusEffectCounters);
                
                //Logic for "other" status effects - armor, increase energy, etc.
                if(NewStatusEffect.Counters <= 0)
                    NewStatusEffect.RemoveStatusEffect.RemoveEffect(hero);
            }

            
        }
        
        
        
        
        
    }
}
