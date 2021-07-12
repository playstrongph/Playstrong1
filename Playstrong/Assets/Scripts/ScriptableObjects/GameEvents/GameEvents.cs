using System.Collections;
using System.Collections.Generic;
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
    public class GameEvents : ScriptableObject, IGameEvents
    {
        [SerializeField] [RequireInterface(typeof(ISkillConditionAsset))]
        private List<Object> skillConditionAssets;

        protected List<ISkillConditionAsset> SkillConditionAssets
        {
            get
            {
                var skillConditions = new List<ISkillConditionAsset>();
                foreach (var skillConditionObject in skillConditionAssets)
                {
                    var skillCondition = skillConditionObject as ISkillConditionAsset;
                    skillConditions.Add(skillCondition);
                }

                return skillConditions;
            }
        }

        protected ICoroutineTree LogicTree;
        protected int Index;

        
        public void SubscribeToEvent(IHero hero)
        {
            LogicTree = hero.CoroutineTreesAsset.MainLogicTree;
            LogicTree.AddCurrent(SubscribeToEventCoroutine(hero));
            
        }
        
        protected virtual IEnumerator SubscribeToEventCoroutine(IHero hero)
        {
            //this is only a sample and should be overriden
            
            /*index = 0;
            var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
                hero.HeroLogic.HeroEvents.EBeforeAttacking += SkillConditionTarget;    
                index++;
            }*/
            
            Debug.Log("Error: Override default SubscribeToEventCoroutine");
            LogicTree.EndSequence();  
            yield return null;
            
        }
        
        protected void SkillConditionTarget(IHero hero, IHero dummyHero)
        {
            var skillConditions = SkillConditionAssets;
            skillConditions[Index].Target(hero, hero);
        }



    }
}
