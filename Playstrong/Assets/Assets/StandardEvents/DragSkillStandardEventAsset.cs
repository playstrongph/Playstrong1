using System.Collections;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace Assets.StandardEvents
{
    [CreateAssetMenu(fileName = "DragSkillTarget", menuName = "SO's/StandardActions/DragSkillTarget")]
    public class DragSkillStandardEventAsset : StandardEventsAsset
    {
        protected override IEnumerator SubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            //Note that the event Dictates the args of the StartAction subscribed
            skill.SkillLogic.SkillEvents.EDragSkillTarget += standardAction.StartAction;
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            //Note that the event Dictates the args of the StartAction subscribed
            skill.SkillLogic.SkillEvents.EDragSkillTarget -= standardAction.StartAction;
            yield return null;
        }
    }
}
