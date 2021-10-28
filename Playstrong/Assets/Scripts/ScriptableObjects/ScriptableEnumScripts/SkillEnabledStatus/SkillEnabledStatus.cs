using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    public class SkillEnabledStatus : ScriptableObject, ISkillEnabledStatus
    {
        public virtual void DisableSkill(ISkill skill)
        {
        }
        
        public virtual void EnableSkill(ISkill skill)
        {
        }

        public virtual void SetSkillReady(ISkill skill)
        {
            //If skill is Disabled - do Nothing
        }
        
        public virtual void SetSkillNotReady(ISkill skill)
        {
            skill.SkillLogic.UpdateSkillReadiness.SetSkillNotReady();
        }

        



    }
}
