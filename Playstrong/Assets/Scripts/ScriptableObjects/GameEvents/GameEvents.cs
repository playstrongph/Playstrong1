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

        private ICoroutineTree _logicTree;

        
        public void SubscribeToEvent(IHero hero)
        {
            _logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            _logicTree.AddCurrent(SubscribeToEventCoroutine(hero));
            
        }

        //Sample Event - EBeforeAttacking
        protected virtual IEnumerator SubscribeToEventCoroutine(IHero hero)
        {

            hero.HeroLogic.HeroEvents.EBeforeAttacking += SkillConditionTarget;

            _logicTree.EndSequence();  
            yield return null;
            
        }

        private void SkillConditionTarget(IHero hero, IHero dummyHero)
        {
           SkillConditionAsset.Target(hero, hero);
        }



    }
}
