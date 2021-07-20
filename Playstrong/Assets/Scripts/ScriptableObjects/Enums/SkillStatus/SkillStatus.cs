using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    public class SkillStatus : ScriptableObject, ISkillStatus
    {
        public virtual void StatusAction(ISkillLogic skillLogic)
        {
            
        }
        
        
    }
}
