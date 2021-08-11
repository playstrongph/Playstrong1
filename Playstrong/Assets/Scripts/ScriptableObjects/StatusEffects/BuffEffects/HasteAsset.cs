using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Haste", menuName = "SO's/Status Effects/Buffs/Haste")]
    public class HasteAsset : StatusEffectAsset
    {
        [SerializeField]
        private float multiplier =  0.3f;
        
        private int _speedIncrease;

        public override void ApplyStatusEffect(IHero hero)
        {
            ComputeSpeedIncrease(hero);

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, EffectValue));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -EffectValue));
        }

        private void ComputeSpeedIncrease(IHero hero)
        {
            var baseSpeed = hero.HeroLogic.HeroAttributes.Speed;
            EffectValue = Mathf.FloorToInt(multiplier * baseSpeed);
        }





    }
}
