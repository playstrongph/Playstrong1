using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Resurrect", menuName = "SO's/Status Effects/Buffs/Resurrect")]
    public class ResurrectAsset : StatusEffectAsset
    {
        private float dummyValue = 0f;
        
        [SerializeField]
        private float resurrectChance = 100f;

        public override void ApplyStatusEffect(IHero hero)
        {
            //TODO: IncreaseResurrect Chance Action
            hero.HeroLogic.OtherAttributes.ResurrectChance += resurrectChance;
            //hero.HeroLogic.HeroEvents.EPostHeroDeath += ResurrectAction;
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.OtherAttributes.ResurrectChance -= resurrectChance;
            //hero.HeroLogic.HeroEvents.EPostHeroDeath -= ResurrectAction;
            base.UnapplyStatusEffect(hero);
        }


        private void ResurrectAction(IHero hero)
        {
            Debug.Log("Resurrect Action");
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(ResurrectHero(hero));
        }


        private IEnumerator ResurrectHero(IHero hero)
        {
            Debug.Log("Resurrect Hero");
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Action target used here because hero living status is dead
            logicTree.AddCurrent(SkillActionAsset.ActionTarget(hero,dummyValue));

            logicTree.EndSequence();
            yield return null;
            
        }
        
        //TEST
        public override void RemoveStatusEffectOnDeath(IHero hero)
        {
           //Don't Destroy At Death
        }

       
        
        










    }
}
