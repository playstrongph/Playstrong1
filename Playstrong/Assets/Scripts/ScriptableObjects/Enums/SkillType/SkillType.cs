using Interfaces;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    public class SkillType : ScriptableObject, ISkillType
    {
        [SerializeField] private int _skillCdIndex;
        public int SkillCdIndex => _skillCdIndex;

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
    }
}
