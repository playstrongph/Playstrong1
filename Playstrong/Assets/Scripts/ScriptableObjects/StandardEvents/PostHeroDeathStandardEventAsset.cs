using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "PostHeroDeath", menuName = "SO's/StandardEvents/PostHeroDeath")]
    public class PostHeroDeathStandardEventAsset : StandardEventsAsset
    {
        protected override IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            //Debug.Log("Subscribe to PostHeroDeath: " +hero.HeroName);
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            hero.HeroLogic.HeroEvents.EPostHeroDeath -= standardAction.StartAction;
            //Note that the event Dictates the args of the StartAction subscribed
            hero.HeroLogic.HeroEvents.EPostHeroDeath += standardAction.StartAction;

            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            //Debug.Log("Unsubscribe to PostHeroDeath: " +hero.HeroName);
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            //hero.HeroLogic.HeroEvents.EPostHeroDeath -= standardAction.StartAction;

            logicTree.EndSequence();
            yield return null;
        }
    }
}
