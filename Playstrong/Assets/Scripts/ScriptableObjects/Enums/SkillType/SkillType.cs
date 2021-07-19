using Interfaces;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    public class SkillType : ScriptableObject, ISkillType
    {
        public virtual void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            //set cooldown.enabled status
        }

        public virtual void ReduceSkillCd(ISkill skill, int counter)
        {
            //No action for Passive Skills
            //ReduceCd for Active Skills
            //ReduceCD for CdPassiveSkills
        }

        public virtual void ResetSkillCd(ISkill skill)
        {
            //No action for Passive Skills
            //Max Cooldown for Active Skills
            //Max Cooldown for CdPassive Skills
        }
    }
}
