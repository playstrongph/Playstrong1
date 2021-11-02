using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "PostHeroEndTurn", menuName = "SO's/StandardEvents/PostHeroEndTurn")]
    public class PostHeroEndTurnStandardEventAsset : StandardEventsAsset
    {
        /// <summary>
        /// Event Used by Status Effects
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        protected override IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
          
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            //skill.SkillLogic.SkillEvents.EDragSkillTarget += standardAction.StartAction;
            hero.HeroLogic.HeroEvents.EPostHeroEndTurn += standardAction.StartAction;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            hero.HeroLogic.HeroEvents.EPostHeroEndTurn -= standardAction.StartAction;
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
