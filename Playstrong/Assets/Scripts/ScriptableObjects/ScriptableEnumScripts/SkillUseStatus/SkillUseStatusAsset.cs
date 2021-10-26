using System.Collections;
using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    public class SkillUseStatusAsset : ScriptableObject, ISkillUseStatusAsset
    {
        public virtual int UsingSkill(ISkill skill)
        {
            return 0;
        }
        
        public virtual int NotUsingSkill(ISkill skill)
        {
            return 0;
        }
        
        //TEST
        public virtual IEnumerator StatusAction(ISkill skill, int value)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            skill.SkillLogic.SkillAttributes.SkillType.ReduceSkillCd(skill, value);

            logicTree.EndSequence();
            yield return null;

        }
        
       
        
        

      



    }
}
