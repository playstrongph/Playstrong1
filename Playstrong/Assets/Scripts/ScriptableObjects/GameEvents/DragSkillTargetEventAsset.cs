using System.Collections;
using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.GameEvents
{
    [CreateAssetMenu(fileName = "DragSkillTarget", menuName = "SO's/GameEvents/DragSkillTarget")]
    public class DragSkillTargetEventAsset : GameEvents
    {
        protected override IEnumerator SubscribeToSkillEventsCoroutine(ISkill skill)
        {
            var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
                skill.SkillLogic.SkillEvents.EDragSkillTarget += skillCondition.UseSkillAction;
                
                //Debug.Log("Register to EDragSkillTarget: " +skill.SkillName);
             
            }
            
            LogicTree.EndSequence();  
            yield return null;
        }


    }
}
