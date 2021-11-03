using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Haste", menuName = "SO's/Status Effects/Buffs/Haste")]
    public class HasteAsset : StatusEffectAsset
    {
        
        public override void ApplyStatusEffect(IHero hero)
        {
            //EffectValue = ComputeSpeedIncrease(hero);
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }

        





    }
}
