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

        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EPostHeroDeath += ResurrectAction;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EPostHeroDeath -= ResurrectAction;
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
            
            logicTree.AddCurrent(SkillActionAsset.ActionTarget(hero,dummyValue));

            logicTree.EndSequence();
            yield return null;
            
        }

        private IEnumerator DestroyBuff(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            

            logicTree.EndSequence();
            yield return null;
        }
        
        










    }
}
