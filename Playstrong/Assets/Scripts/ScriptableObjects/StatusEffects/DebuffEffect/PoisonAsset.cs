using Interfaces;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Poison", menuName = "SO's/Status Effects/Debuffs/Poison")]
    public class PoisonAsset : StatusEffectAsset
    {
        [Header("Set Damage Factor Hero Basis")]
        [SerializeField] private ScriptableObject damageFactor;
        private ICalculatedFactorValueAsset DamageFactor  => damageFactor as ICalculatedFactorValueAsset;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            //TODO: Test Only.  Transfer this into a BasicAction
            DamageFactor.SetHeroBasis(hero);
            
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }

        








    }
}
