using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Haste", menuName = "SO's/Status Effects/Buffs/Haste")]
    public class HasteAsset : StatusEffectAsset
    {
        [SerializeField]
        private float multiplier =  0.3f;
        
        [SerializeField] private float factor = 30f;

        private float speedValue;

        public override void ApplyStatusEffect(IHero hero)
        {
            EffectValue = ComputeSpeedIncrease(hero);
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }

        private float ComputeSpeedIncrease(IHero hero)
        {
            var baseSpeed = hero.HeroLogic.HeroAttributes.BaseSpeed;
            speedValue = Mathf.FloorToInt(factor * baseSpeed/100);
            return speedValue;
        }





    }
}
