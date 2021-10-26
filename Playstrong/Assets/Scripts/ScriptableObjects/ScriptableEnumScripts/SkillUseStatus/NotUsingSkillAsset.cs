using System.Collections;
using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "NotUsingSkill", menuName = "SO's/Scriptable Enums/SkillUseStatus/NotUsingSkill")]
    public class NotUsingSkillAsset : SkillUseStatusAsset
    {
        public override int NotUsingSkill(ISkill skill)
        {
            return 1;
        }
        
        

    }
}
