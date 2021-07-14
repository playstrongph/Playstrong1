using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
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
        
        public void SubscribeToHeroEvents(IHero hero)
        {
            LogicTree = hero.CoroutineTreesAsset.MainLogicTree;
            LogicTree.AddCurrent(SubscribeToHeroEventsCoroutine(hero));
            
        }
        
        protected virtual IEnumerator SubscribeToHeroEventsCoroutine(IHero hero)
        {
            //this is only a sample and should be overriden
            
            /*index = 0;
            var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
                hero.HeroLogic.HeroEvents.EBeforeAttacking += SkillConditionTarget;    
                index++;
            }*/

            LogicTree.EndSequence();  
            yield return null;
            
        }
        
        public void SubscribeToSkillEvents(ISkill skill)
        {
            LogicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            LogicTree.AddCurrent(SubscribeToSkillEventsCoroutine(skill));
            
        }
        
        protected virtual IEnumerator SubscribeToSkillEventsCoroutine(ISkill skill)
        {
            //this is only a sample and should be overriden
            
            /*var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
                skill.SkillLogic.SkillEvents.EDragSkillTarget += SkillConditionTarget;

            }*/
            
            LogicTree.EndSequence();  
            yield return null;
            
        }
        
       



    }
}
