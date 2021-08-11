using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "AttackUp", menuName = "SO's/Status Effects/Buffs/AttackUp")]
    public class AttackUpAsset : StatusEffectAsset
    {
        [SerializeField]
        private float multiplier =0.5f;

        public override void ApplyStatusEffect(IHero hero)
        {
            ComputeAttackIncrease(hero);
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, EffectValue));
            
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -EffectValue));
        }

        private void ComputeAttackIncrease(IHero hero)
        {
            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            EffectValue = Mathf.FloorToInt(multiplier * baseAttack);
            
        }





    }
}
