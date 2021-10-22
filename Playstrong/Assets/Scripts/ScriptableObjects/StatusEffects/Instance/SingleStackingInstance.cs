using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    //TODO: Obsolete for cleanup
    [CreateAssetMenu(fileName = "SingleStackingInstance", menuName = "SO's/Status Effects/Instance/SingleStackingInstance")]
    public class SingleStackingInstance : StatusEffectInstance
    {
        
        public override void AddStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {
            
            var existingStatusEffect =  CheckExistingStatusEffects(targetHero, statusEffectAsset);

            if (existingStatusEffect != null)
                UpdateStackingStatusEffect(existingStatusEffect, statusEffectAsset, statusEffectCounters, targetHero,casterHero);
            else
            {
                NewStatusEffect = CreateStackingStatusEffect(targetHero, statusEffectAsset, statusEffectCounters,casterHero);
                
                //Logic for 1 time "other" status effects - armor, increase energy, etc.
                if(NewStatusEffect.Counters <= 0)
                    NewStatusEffect.RemoveStatusEffect.RemoveEffect(targetHero);
            }
        }

    }
}
