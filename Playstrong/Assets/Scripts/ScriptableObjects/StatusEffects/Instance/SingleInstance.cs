using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "SingleInstance", menuName = "SO's/Status Effects/Instance/Single Instance")]
    public class SingleInstance : StatusEffectInstance
    {
        
        public override void AddStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {
            //TEST
            var existingStatusEffect =  CheckExistingStatusEffects(targetHero, statusEffectAsset);

            if (existingStatusEffect != null)
                UpdateStatusEffect(existingStatusEffect, statusEffectAsset, statusEffectCounters, targetHero,casterHero);
            else
            {
                NewStatusEffect = CreateStatusEffect(targetHero, statusEffectAsset, statusEffectCounters,casterHero);
                
                //Logic for "other" status effects - armor, increase energy, etc.
                if(NewStatusEffect.Counters <= 0)
                    NewStatusEffect.RemoveStatusEffect.RemoveEffect(targetHero);
            }
        }

    }
}
