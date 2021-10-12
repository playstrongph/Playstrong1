using System.Collections;
using System.Collections.Generic;
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
        //Effect: At the start of the hero's turn, +2 attack.  Max of 5 counters
        private float _cumulativeValue = 0f;

        [SerializeField] private float attackUpValue;
        
        public override void ApplyStatusEffect(IHero hero)
        {
           //For Stacking Effects, subscribe event here
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            //For Stacking Effects, unsubscribe event here
        }

       


        public override void ApplyStackingEffect(IHero hero)
        {
            /*ComputeAttackIncrease(hero);
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, attackUpValue));*/

            
        }

        public override void UnapplyStackingEffect(IHero hero)
        {
            /*var effectValue = _cumulativeValue;
            _cumulativeValue = 0;
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -effectValue));*/
        }

        private void ComputeAttackIncrease(IHero hero)
        {
            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            
            attackUpValue = Mathf.FloorToInt(multiplier * baseAttack);
            //Test
            attackUpValue = 2;
            
            _cumulativeValue += attackUpValue;
        }

        private IEnumerator TestDestroy(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //HeroStatusEffectReference.RemoveStatusEffect.RemoveEffect(hero);
            
            logicTree.EndSequence();
            yield return null;
        }





    }
}
