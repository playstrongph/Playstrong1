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
           
           //sample
           //Note that the event Dictates the args of the StartAction subscribed
           //hero.HeroLogic.HeroEvents.EAfterHeroDies += standardAction.StartAction;
            
            yield return null;
            
        }
        protected virtual IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            //sample
            //Note that the event Dictates the args of the StartAction subscribed
            //hero.HeroLogic.HeroEvents.EAfterHeroDies -= standardAction.StartAction;
            yield return null;
            
        }
        
        
        public void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SubscribeStandardActionCoroutine(skill, standardAction));
        }
        public void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UnsubscribeStandardActionCoroutine(skill,standardAction));
        }
        
        protected virtual IEnumerator SubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            //sample
            //Note that the event Dictates the args of the StartAction subscribed
            //skill.SkillLogic.SkillEvents.EDragSkillTarget += standardAction.StartAction;
            yield return null;
            
        }
        
        protected virtual IEnumerator UnsubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            //sample
            //Note that the event Dictates the args of the StartAction subscribed
            //skill.SkillLogic.SkillEvents.EDragSkillTarget -= standardAction.StartAction;
            yield return null;
            
        }

    }
}
