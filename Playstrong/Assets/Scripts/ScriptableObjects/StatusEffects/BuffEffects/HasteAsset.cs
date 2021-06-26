using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Haste", menuName = "SO's/Status Effects/Buffs/Haste")]
    public class HasteAsset : StatusEffectAsset
    {
       
        private int _speedIncrease;
        private float _multiplier = 0.3f;

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        
        public override void ApplyStatusEffect(IHero hero)
        {
            InitializeValues(hero);

            var newSpeedValue = hero.HeroLogic.HeroAttributes.Speed + _speedIncrease;

            hero.HeroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);
            
            
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var newSpeedValue = hero.HeroLogic.HeroAttributes.Speed - _speedIncrease;
            
            hero.HeroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);
            
        }

        private void InitializeValues(IHero hero)
        {
            _logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = hero.CoroutineTreesAsset.MainVisualTree;

            var baseSpeed = hero.HeroLogic.HeroAttributes.Speed;
            _speedIncrease = Mathf.FloorToInt(_multiplier * baseSpeed);
        }





    }
}
