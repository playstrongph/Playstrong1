﻿using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "NoDispel", menuName = "SO's/Status Effects/Instance/No Dispel")]
    public class NoDispelInstance : StatusEffectInstance
    {
        
        public override void AddStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {
            
            CheckExistingStatusEffects(targetHero, statusEffectAsset);
            
            if (ExistingStatusEffect != null)
                UpdateStatusEffect(ExistingStatusEffect, statusEffectAsset, statusEffectCounters, targetHero,casterHero);
            else
            {
                NewStatusEffect = CreateStatusEffect(targetHero, statusEffectAsset, statusEffectCounters,casterHero);
                
                //Logic for "other" status effects - armor, increase energy, etc.
                if(NewStatusEffect.Counters <= 0)
                    NewStatusEffect.RemoveStatusEffect.RemoveEffect(targetHero);
            }
        }
        
        public override void DispelStatusEffect(IHeroStatusEffect existingStatusEffect, IHero targetHero)
        {
          
        }
        
        

    }
}
