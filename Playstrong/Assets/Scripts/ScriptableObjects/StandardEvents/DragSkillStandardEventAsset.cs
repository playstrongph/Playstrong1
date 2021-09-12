using System.Collections;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StandardEvents
{
    [CreateAssetMenu(fileName = "DragSkillTarget", menuName = "SO's/StandardEvents/DragSkillTarget")]
    public class DragSkillStandardEventAsset : StandardEventsAsset
    {
        protected override IEnumerator SubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            skill.SkillLogic.SkillEvents.EDragSkillTarget += standardAction.StartAction;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            //Note that the event Dictates the args of the StartAction subscribed
            skill.SkillLogic.SkillEvents.EDragSkillTarget -= standardAction.StartAction;
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
