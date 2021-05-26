using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Enums
{
    [CreateAssetMenu(fileName = "Passive Skill", menuName = "SO's/Scriptable Enums/Passive Skill")]
    public class PassiveSkillAsset : ScriptableObject, IPassiveSkillAsset, ISkillType
    {

        [SerializeField] private int _skillCdIndex = 1;
        public int SkillCdIndex => _skillCdIndex;

    }
}
