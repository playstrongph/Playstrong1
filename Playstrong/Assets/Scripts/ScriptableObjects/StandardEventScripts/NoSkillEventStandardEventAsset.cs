using System.Collections;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "NoSkillEvent", menuName = "SO's/StandardEvents/NoSkillEvent")]
    public class NoSkillEventStandardEventAsset : StandardEventsAsset
    {
        protected override IEnumerator SubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            Debug.Log("Subscribe: No Event");
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            Debug.Log("Unsubscribe: No Event");

            logicTree.EndSequence();
            yield return null;
        }
    }
}
