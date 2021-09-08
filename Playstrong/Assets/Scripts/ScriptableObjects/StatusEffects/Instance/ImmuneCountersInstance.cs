using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "ImmuneCountersInstance", menuName = "SO's/Status Effects/Instance/ImmuneCountersInstance")]
    public class ImmuneCountersInstance : StatusEffectInstance
    {
        
        public override void AddStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {
            
            var existingStatusEffects =  CheckExistingStatusEffects(targetHero, statusEffectAsset);
            
            if (existingStatusEffects != null)
                UpdateStatusEffect(existingStatusEffects, statusEffectAsset, statusEffectCounters, targetHero,casterHero);
            else
            {
                NewStatusEffect = CreateStatusEffect(targetHero, statusEffectAsset, statusEffectCounters,casterHero);
                
                //Logic for "other" status effects - armor, increase energy, etc.
                if(NewStatusEffect.Counters <= 0)
                    NewStatusEffect.RemoveStatusEffect.RemoveEffect(targetHero);
            }
        }
        
        public override void IncreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
           
        }
        
        public override void DecreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
           
        }
        
        public override void SetCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
          
        }


    }
}
