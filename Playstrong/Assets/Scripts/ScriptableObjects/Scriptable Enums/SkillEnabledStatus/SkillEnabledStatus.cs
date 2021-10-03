using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    public class SkillEnabledStatus : ScriptableObject, ISkillEnabledStatus
    {
        public virtual void DisableActiveSkill(ISkill skill)
        {
            
        }
        
        public virtual void EnableActiveSkill(ISkill skill)
        {
            
        }
        
        public virtual void DisablePassiveSkill(ISkill skill)
        {
            
        }
        
        public virtual void EnablePassiveSkill(ISkill skill)
        {
            
        }

      



    }
}
