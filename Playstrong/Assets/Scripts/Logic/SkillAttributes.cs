using Interfaces;
using ScriptableObjects.Enums;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class SkillAttributes : MonoBehaviour, ISkillAttributes
    {
        
        [SerializeField] private int _baseCooldown;

        public int BaseCooldown
        {
            get => _baseCooldown;
            set => _baseCooldown = value;
        }
        
        [SerializeField] private int _cooldown;

        public int Cooldown
        {
            get => _cooldown;
            set => _cooldown = value;
        }

        [SerializeField] [RequireInterface(typeof(ISkillStatus))]
        private ScriptableObject _skillStatus;

        public ISkillStatus SkillStatus
        {
            get => _skillStatus as ISkillStatus;
            set => _skillStatus = value as ScriptableObject;
        }


        [Header("Set in Script")]
        [SerializeField] [RequireInterface(typeof(ISkillType))]
        private ScriptableObject _skillType;

        public ISkillType SkillType
        {
            get => _skillType as ISkillType;
            set => _skillType = value as ScriptableObject;
        }
        
        [SerializeField] [RequireInterface(typeof(ISkillTarget))]
        private ScriptableObject _skillTarget;

        public ISkillTarget SkillTarget
        {
            get => _skillTarget as ISkillTarget;
            set => _skillTarget = value as ScriptableObject;
        }

       


    }
}
