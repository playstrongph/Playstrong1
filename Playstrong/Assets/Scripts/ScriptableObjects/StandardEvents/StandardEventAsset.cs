using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using ScriptableObjects.StandardActions;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.GameEvents
{
    
    /// <summary>
    /// Base class for game event scriptable objects
    /// </summary>
    public class StandardEventAsset : ScriptableObject
    {
        
        public IStandardActionAsset StandardActionAsset { get; set; }

        public void SubscribeToHeroEvents(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SubscribeToHeroEventsCoroutine(hero));

        
        }
        
        public void SubscribeToSkillEvents(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SubscribeToSkillEventsCoroutine(skill));
            
        
        }
        
        public void UnsubscribeToHeroEvents(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(UnsubscribeToHeroEventsCoroutine(hero));

        
        }
        
        public void UnsubscribeToSkillEvents(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(UnsubscribeToSkillEventsCoroutine(skill));
            
        
        }


        /// <summary>
        /// Basic Attack and Passive Skills subscribe here since they'll be using hero events
        /// </summary>
        protected virtual IEnumerator SubscribeToHeroEventsCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.EndSequence();  
            yield return null;
            
        }
        
        protected virtual IEnumerator UnsubscribeToHeroEventsCoroutine(IHero hero)
        { 
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.EndSequence();  
            yield return null;
            
        }

        /// <summary>
        /// Active skills shall subscribe here, since DragSkillTarget events should be
        /// unique per skill - not per hero.
        /// </summary>
        protected virtual IEnumerator SubscribeToSkillEventsCoroutine(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.EndSequence();  
            yield return null;
            
        }
        
        protected virtual IEnumerator UnsubscribeToSkillEventsCoroutine(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();  
            yield return null;
            
        }
        
        
       







    }
}
