using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Sleep", menuName = "SO's/Status Effects/Debuffs/Sleep")]
    public class SleepAsset : StatusEffectAsset
    {
        [SerializeField]
        private int _chanceIncrease = 150;

        [SerializeField] private int _resistanceDecrease = 150;
        

        [SerializeField] private ScriptableObject decreaseCriticalResistance;
        private IHeroAction DecreaseCriticalResistance => decreaseCriticalResistance as IHeroAction;
        

        public override void ApplyStatusEffect(IHero hero) {
       

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, _chanceIncrease));
            logicTree.AddCurrent(DecreaseCriticalResistance.StartAction(hero, _resistanceDecrease));

            hero.HeroLogic.HeroEvents.EPostAttack += DispelSleep;

        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -_chanceIncrease));
            logicTree.AddCurrent(DecreaseCriticalResistance.StartAction(hero, -_resistanceDecrease));
            
            hero.HeroLogic.HeroEvents.EPostAttack -= DispelSleep;
        }

        private void DispelSleep(IHero hero, IHero dummyHero)
        {
            HeroStatusEffectReference.RemoveStatusEffect.RemoveEffect(hero);
        }









    }
}
