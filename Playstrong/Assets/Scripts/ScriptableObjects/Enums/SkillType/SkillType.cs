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
    }
}
