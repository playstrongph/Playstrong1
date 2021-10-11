using Interfaces;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Burn", menuName = "SO's/Status Effects/Debuffs/Burn")]
    public class BurnAsset : StatusEffectAsset
    {
        //
      
        
        public override void ApplyStatusEffect(IHero hero)
        {
            StandardActions[0].BasicActionTargets.CustomHeroTarget = HeroStatusEffectReference.StatusEffectCasterHero;
            
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }

    }
}
