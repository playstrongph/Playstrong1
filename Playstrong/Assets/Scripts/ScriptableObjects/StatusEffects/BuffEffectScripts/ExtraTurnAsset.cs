using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "ExtraTurn", menuName = "SO's/Status Effects/Buffs/ExtraTurn")]
    public class ExtraTurnAsset : StatusEffectAsset
    {
        [SerializeField]
        private float energyIncrease = 1000f;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(SkillActionAsset.StartAction(hero, energyIncrease));
            hero.HeroLogic.HeroEvents.EHeroEndTurn += ExtraTurnLogic;

        }

        private void ExtraTurnLogic(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(ExtraTurnCoroutine(hero));
        }

        private IEnumerator ExtraTurnCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            var heroEnergy = hero.HeroLogic.HeroAttributes.Energy;
            var newEnergy = (int)heroEnergy + (int)energyIncrease;
            
            hero.HeroLogic.SetHeroEnergy.SetEnergy(newEnergy);
            
            logicTree.EndSequence();
            yield return null;
        }



        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroEndTurn -= ExtraTurnLogic;
        }

       





    }
}
