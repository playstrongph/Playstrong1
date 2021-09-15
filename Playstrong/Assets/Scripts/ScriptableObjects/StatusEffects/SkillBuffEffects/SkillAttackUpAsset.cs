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
        //Effect: At the start of the hero's turn, increase attack
        private float _cumulativeValue = 0f;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn += SkillAttackUpEffect;

        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn -= SkillAttackUpEffect;
            UnapplyStackingEffect(hero );
        }

        private void SkillAttackUpEffect(IHero hero)
        {
            ApplyStackingEffect(hero);
        }


        public override void ApplyStackingEffect(IHero hero)
        {
            ComputeAttackIncrease(hero);
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, EffectValue));
        }

        public override void UnapplyStackingEffect(IHero hero)
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
