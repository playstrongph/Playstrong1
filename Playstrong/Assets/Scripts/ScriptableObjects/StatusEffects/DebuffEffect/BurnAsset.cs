using Interfaces;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Burn", menuName = "SO's/Status Effects/Debuffs/Burn")]
    public class BurnAsset : StatusEffectAsset
    {
        
        [SerializeField] private ScriptableObject damageFactor;
        private ICalculatedFactorValueAsset DamageFactor  => damageFactor as ICalculatedFactorValueAsset;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            //this is wrong - value does not update with attack update!
            DamageFactor.SetCalculatedValue(CasterHero);
            
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }

    }
}
