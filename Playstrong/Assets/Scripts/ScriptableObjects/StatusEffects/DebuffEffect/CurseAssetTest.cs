using System.Collections.Generic;
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
        
        public override void ApplyStatusEffect(IHero hero)
        {
            //Have to manually set the CustomHeroTarget in the StandardAction
            //TODO: Create Standard Action Targets List - then use customHeroTarget for all standardaction targets
            //Set targets in a foreach loop?
            StandardActions[1].BasicActionTargets.CustomHeroTarget = HeroStatusEffectReference.StatusEffectTargetHero;

            foreach (var allyHero in hero.AllAllyHeroes)
            {
                base.ApplyStatusEffect(allyHero);   
            }
               
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            foreach (var allyHero in hero.AllAllyHeroes)
            {
                base.UnapplyStatusEffect(allyHero);   
            }
               
        }

    }
}
