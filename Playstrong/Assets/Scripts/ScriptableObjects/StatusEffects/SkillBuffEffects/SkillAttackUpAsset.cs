using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "SkillAttackUp", menuName = "SO's/Status Effects/SkillBuffs/SkillAttackUp")]
    public class SkillAttackUpAsset : StatusEffectAsset
    {
        [SerializeField]
        private float multiplier =0.1f;

        //Cumulative effect value of the stacking status effect 
        private float _cumulativeValue = 0f;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            ComputeAttackIncrease(hero);
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, EffectValue));
            
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var effectValue = _cumulativeValue;
            _cumulativeValue = 0;
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -effectValue));
        }

        private void ComputeAttackIncrease(IHero hero)
        {
            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            EffectValue = Mathf.FloorToInt(multiplier * baseAttack);
            _cumulativeValue += EffectValue;
        }





    }
}
