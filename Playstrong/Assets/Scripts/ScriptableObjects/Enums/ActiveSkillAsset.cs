using Interfaces;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums
{
    [CreateAssetMenu(fileName = "Active Skill", menuName = "SO's/Scriptable Enums/Active Skill")]
    public class ActiveSkillAsset : ScriptableObject, IActiveSkillAsset, ISkillType
    {
        [SerializeField] private int _skillCdIndex = 0;
        public int SkillCdIndex => _skillCdIndex;

        public void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = true;
        }

    }
}
