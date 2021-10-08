﻿using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "CurseTest", menuName = "SO's/Status Effects/Debuffs/CurseTest")]
    public class CurseAssetTest : StatusEffectAsset
    {
        [Header("Basic Action Target")] [SerializeField]
        private ScriptableObject basicActionTargetHero;
        private IActionTargets BasicActionTargetHero=> basicActionTargetHero as IActionTargets;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            //TEST
            BasicActionTargetHero.CustomHeroTarget = HeroStatusEffectReference.StatusEffectTargetHero;
            
            foreach (var allyHero in hero.AllAllyHeroes)
            {
                //TODO: Test only, transfer this to a basic action
                //DamageFactor.SetHeroBasis(allyHero);
                
                base.ApplyStatusEffect(allyHero);   
            }
            //base.ApplyStatusEffect(hero);   
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            foreach (var allyHero in hero.AllAllyHeroes)
            {
                base.UnapplyStatusEffect(allyHero);   
            }
            //base.UnapplyStatusEffect(hero);   
        }

    }
}
