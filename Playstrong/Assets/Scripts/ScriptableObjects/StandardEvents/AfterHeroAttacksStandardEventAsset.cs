﻿using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "AfterHeroAttacks", menuName = "SO's/StandardEvents/AfterHeroAttacks")]
    public class AfterHeroAttacksStandardEventAsset : StandardEventsAsset
    {

        protected override IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
           
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            //skill.SkillLogic.SkillEvents.EDragSkillTarget += standardAction.StartAction;
            
            hero.HeroLogic.HeroEvents.EAfterAttacking += standardAction.StartAction;
            
            Debug.Log("After Hero Attacks: " +hero.HeroName);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            hero.HeroLogic.HeroEvents.EAfterAttacking -= standardAction.StartAction;
            
            Debug.Log("After Hero Attacks: " +hero.HeroName);
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
