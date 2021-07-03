using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Haste", menuName = "SO's/Status Effects/Buffs/Haste")]
    public class HasteAsset : StatusEffectAsset
    {
        [SerializeField]
        private float _multiplier;
        
        private int _speedIncrease;

        public override void ApplyStatusEffect(IHero hero)
        {
            InitializeValues(hero);
            ComputeSpeedIncrease();

            var newSpeedValue = hero.HeroLogic.HeroAttributes.Speed + _speedIncrease;
            hero.HeroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);
            
            
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var newSpeedValue = hero.HeroLogic.HeroAttributes.Speed - _speedIncrease;
            
            hero.HeroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);
            
        }

        private void ComputeSpeedIncrease()
        {
            var baseSpeed = Hero.HeroLogic.HeroAttributes.Speed;
            _speedIncrease = Mathf.FloorToInt(_multiplier * baseSpeed);
        }





    }
}
