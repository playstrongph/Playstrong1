using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "HeroEndTurn", menuName = "SO's/StandardEvents/HeroEndTurn")]
    public class HeroEndTurnStandardEventAsset : StandardEventsAsset
    {
        protected override IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
           
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            //skill.SkillLogic.SkillEvents.EDragSkillTarget += standardAction.StartAction;
            hero.HeroLogic.HeroEvents.EHeroEndTurn += standardAction.StartAction;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            hero.HeroLogic.HeroEvents.EHeroEndTurn -= standardAction.StartAction;
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
