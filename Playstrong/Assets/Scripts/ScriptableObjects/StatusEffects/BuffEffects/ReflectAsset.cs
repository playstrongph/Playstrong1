using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Reflect", menuName = "SO's/Status Effects/Buffs/Reflect")]
    public class ReflectAsset : StatusEffectAsset
    {
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
