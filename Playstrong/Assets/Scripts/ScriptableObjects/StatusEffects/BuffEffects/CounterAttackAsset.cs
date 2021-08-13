using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "CounterAttack", menuName = "SO's/Status Effects/Buffs/CounterAttack")]
    public class CounterAttack : StatusEffectAsset
    {
        [SerializeField]
        private float counterattackValue = 100f;
        
        [Header("Additional Attributes")]
        [SerializeField] private ScriptableObject _counterResistance;
        private IHeroAction CounterResistance => _counterResistance as IHeroAction;

        [SerializeField] private float counterResistanceValue = 200f;
        
        

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, counterattackValue));
            
            //Register CounterResistance Effect here:  BeforeAttacking and Afterattacking
            hero.HeroLogic.HeroEvents.EBeforeCounterAttack += TemporaryCounterResistanceIncrease;
            hero.HeroLogic.HeroEvents.EAfterCounterAttack += RemoveTemporaryCounterResistanceIncrease;

        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -counterattackValue));
            
            //Remove Register CounterResistance Effect here:  BeforeAttacking and Afterattacking
            hero.HeroLogic.HeroEvents.EBeforeCounterAttack -= TemporaryCounterResistanceIncrease;
            hero.HeroLogic.HeroEvents.EAfterCounterAttack -= RemoveTemporaryCounterResistanceIncrease;
        }


        private void TemporaryCounterResistanceIncrease(IHero hero, IHero dummyHero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(CounterResistance.StartAction(hero, counterResistanceValue));
            
        }
        
        private void RemoveTemporaryCounterResistanceIncrease(IHero hero, IHero dummyHero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(CounterResistance.StartAction(hero, -counterResistanceValue));
        }
        
        







    }
}
