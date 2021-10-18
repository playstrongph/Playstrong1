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
        
       
        
        

      



    }
}
