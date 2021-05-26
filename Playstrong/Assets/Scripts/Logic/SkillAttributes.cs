using Interfaces;
using ScriptableObjects.Enums;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class SkillAttributes : MonoBehaviour, ISkillAttributes
    {
        [SerializeField] private int _cooldown;

        public int Cooldown
        {
            get => _cooldown;
            set => _cooldown = value;
        }

        [SerializeField] private int _baseCooldown;

        public int BaseCooldown
        {
            get => _baseCooldown;
            set => _baseCooldown = value;
        }

        [Header("Set in Script")]
        [SerializeField] [RequireInterface(typeof(ISkillType))]
        private ScriptableObject _skillType;

        public ISkillType SkillType
        {
            get => _skillType as ISkillType;
            set => _skillType = value as ScriptableObject;
        }



    }
}
