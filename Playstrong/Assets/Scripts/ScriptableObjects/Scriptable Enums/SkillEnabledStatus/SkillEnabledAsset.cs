using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillEnabled", menuName = "SO's/Scriptable Enums/SkillEnabledStatus/SkillEnabled")]
    public class SkillEnabledAsset : SkillEnabledStatus
    {
        
        public override void DisableActiveSkill(ISkill skill)
        {
            
        }
        
        public override void EnableActiveSkill(ISkill skill)
        {
            
        }
        
        public override void DisablePassiveSkill(ISkill skill)
        {
            
        }
        
        public override void EnablePassiveSkill(ISkill skill)
        {
            
        }

        public override void SetSkillReadinessToReady(ISkill skill)
        {
            
        }



    }
}
