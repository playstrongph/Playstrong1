using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    
    /// <summary>
    /// Used by StatusEffects and Static Passive Skills
    /// </summary>
    [CreateAssetMenu(fileName = "NoHeroEvent", menuName = "SO's/StandardEvents/NoHeroEvent")]
    public class NoHeroEventStandardEventAsset : StandardEventsAsset
    {
        protected override IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            standardAction.StartAction(hero);

            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            standardAction.UndoStartAction(hero);
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
