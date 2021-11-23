using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "AfterHeroEnablesPassiveSkill", menuName = "SO's/StandardEvents/AfterHeroEnablesPassiveSkill")]
    public class AfterHeroEnablesPassiveSkillStandardEventAsset : StandardEventsAsset
    {

        protected override IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
           
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            //skill.SkillLogic.SkillEvents.EDragSkillTarget + standardAction.StartAction;
            Debug.Log("Event Subscribe AfterHeroEnablesPassiveSkill");
            
            hero.HeroLogic.HeroEvents.EAfterHeroEnablesPassiveSkill += standardAction.StartAction;

            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            hero.HeroLogic.HeroEvents.EAfterHeroEnablesPassiveSkill -= standardAction.StartAction;

            logicTree.EndSequence();
            yield return null;
        }
    }
}
