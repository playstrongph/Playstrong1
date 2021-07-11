using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.GameEvents
{
    
    /// <summary>
    /// Base class for game event scriptable objects
    /// </summary>
    public class GameEvents : ScriptableObject
    {
        [SerializeField] [RequireInterface(typeof(ISkillConditionAsset))]
        private Object skillConditionAsset;
        private ISkillConditionAsset SkillConditionAsset => skillConditionAsset as ISkillConditionAsset;

        protected ICoroutineTree LogicTree;

        
        public void SubscribeToEvent(IHero hero)
        {
            LogicTree = hero.CoroutineTreesAsset.MainLogicTree;
            LogicTree.AddCurrent(SubscribeToEventCoroutine(hero));
            
        }
        
        protected virtual IEnumerator SubscribeToEventCoroutine(IHero hero)
        {
            //this is only a sample and should be overriden
            //hero.HeroLogic.HeroEvents.EBeforeAttacking += SkillConditionTarget;

            LogicTree.EndSequence();  
            yield return null;
            
        }

        protected void SkillConditionTarget(IHero hero, IHero dummyHero)
        {
           SkillConditionAsset.Target(hero, hero);
        }



    }
}
