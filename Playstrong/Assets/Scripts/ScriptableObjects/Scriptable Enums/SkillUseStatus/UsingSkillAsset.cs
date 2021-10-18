using System.Collections;
using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "UsingSkill", menuName = "SO's/Scriptable Enums/SkillUseStatus/UsingSkill")]
    public class UsingSkillAsset : SkillUseStatusAsset
    {
        public override int UsingSkill(ISkill skill)
        {
            return 1;
        }

    }
}
