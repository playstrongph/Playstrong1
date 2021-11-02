using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "PreHeroStartTurn", menuName = "SO's/StandardEvents/PreHeroStartTurn")]
    public class PreHeroStartTurnStandardEventAsset : StandardEventsAsset
    {
        /// <summary>
        /// Event Used by Status Effects
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        protected override IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            //Debug.Log("Subscribe to Event EDragSkillTarget");
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            //skill.SkillLogic.SkillEvents.EDragSkillTarget += standardAction.StartAction;
            
            hero.HeroLogic.HeroEvents.EPreHeroStartTurn += standardAction.StartAction;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            hero.HeroLogic.HeroEvents.EPreHeroStartTurn -= standardAction.StartAction;
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
