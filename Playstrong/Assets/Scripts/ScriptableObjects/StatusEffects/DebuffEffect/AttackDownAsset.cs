using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "AttackDown", menuName = "SO's/Status Effects/Debuffs/AttackDown")]
    public class AttackDownAsset : StatusEffectAsset
    {
        [SerializeField]
        private float multiplier =0.5f;

        public override void ApplyStatusEffect(IHero hero)
        {
            ComputeAttackDecrease(hero);
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, EffectValue));
            
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -EffectValue));
        }

        private void ComputeAttackDecrease(IHero hero)
        {
            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            EffectValue = Mathf.FloorToInt(multiplier * baseAttack);
            
        }





    }
}
