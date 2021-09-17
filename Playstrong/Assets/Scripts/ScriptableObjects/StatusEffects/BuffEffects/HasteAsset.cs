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

        public override void ApplyStatusEffect(IHero hero)
        {
            ComputeSpeedIncrease(hero);

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(SkillActionAsset.StartAction(hero, EffectValue));
            
            StandardAction.StartAction(hero,EffectValue);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -EffectValue));
            
            StandardAction.StartAction(hero,-EffectValue);
        }

        private void ComputeSpeedIncrease(IHero hero)
        {
            var baseSpeed = hero.HeroLogic.HeroAttributes.BaseSpeed;
            EffectValue = Mathf.FloorToInt(factor * baseSpeed/100);
        }





    }
}
