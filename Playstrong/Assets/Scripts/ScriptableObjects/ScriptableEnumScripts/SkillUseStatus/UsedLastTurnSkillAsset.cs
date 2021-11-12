using System.Collections;
using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "UsedLastTurn", menuName = "SO's/Scriptable Enums/SkillUseStatus/UsedLastTurn")]
    public class UsedLastTurnSkillAsset : SkillUseStatusAsset
    {
        public override IEnumerator StatusAction(ISkill skill, int value)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            skill.SkillLogic.UpdateSkillUseStatus.SetHeroNotUsingSkill();
            
            //skill.SkillLogic.SkillAttributes.SkillType.ReduceSkillCd(skill, value);

            logicTree.EndSequence();
            yield return null;

        }
        
         public override int UsingSkill(ISkill skill)
         {
           return 1;
         }

    }
}
