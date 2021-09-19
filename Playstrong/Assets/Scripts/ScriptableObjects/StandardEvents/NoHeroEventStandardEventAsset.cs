using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "NoHeroEvent", menuName = "SO's/StandardEvents/NoHeroEvent")]
    public class NoHeroEventStandardEventAsset : StandardEventsAsset
    {
        protected override IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            Debug.Log("Subscribe: No Event");
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            Debug.Log("Unsubscribe: No Event");
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
