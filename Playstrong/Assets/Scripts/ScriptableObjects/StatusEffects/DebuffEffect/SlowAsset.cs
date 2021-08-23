using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Slow", menuName = "SO's/Status Effects/Debuffs/Slow")]
    public class SlowAsset : StatusEffectAsset
    {
        [SerializeField]
        private float multiplier =  0.3f;
        
        private int _speedDecrease;

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
            var baseSpeed = hero.HeroLogic.HeroAttributes.BaseSpeed;
            EffectValue = Mathf.FloorToInt(multiplier * baseSpeed);
        }





    }
}
