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
        
        public override void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
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
