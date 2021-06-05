using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "None Skill", menuName = "SO's/Scriptable Enums/Skill Type None")]
    public class NoneSkillAsset : ScriptableObject, ISkillType
    {
        [SerializeField] private int _skillCdIndex = 0;
        public int SkillCdIndex => _skillCdIndex;

        public void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            //cooldown.enabled = true;
        }

    }
}
