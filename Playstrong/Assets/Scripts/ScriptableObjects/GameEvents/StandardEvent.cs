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
    
    
    public class StandardEvent : ScriptableObject, IStandardEvent
    {
        //START OF METHODS
        
        public void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SubscribeStandardActionCoroutine(hero, standardAction));
        }

        public void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UnsubscribeStandardActionCoroutine(hero,standardAction));
        }
        
       


       
        protected virtual IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
           
           
            
            yield return null;
            
        }
        
        protected virtual IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
          
            yield return null;
            
        }

       
        
        /*public void SubscribeToSkillEvents(ISkill skill)
        {
        }
        public void UnsubscribeToSkillEvents(ISkill skill)
        {
        }*/
        /*protected virtual IEnumerator SubscribeToSkillEventsCoroutine(ISkill skill)
        {
           
            yield return null;
            
        }
        
        protected virtual IEnumerator UnsubscribeToSkillEventsCoroutine(ISkill skill)
        {
           
            yield return null;
            
        }*/
        
        
    







    }
}
