using System;
using Interfaces;
using References;
using ScriptableObjects.Enums;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using ScriptableObjects.ScriptableEnumScripts.SkillCooldownType;
using ScriptableObjects.SkillEffects;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

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

        [Header("Set in Script")]
        [SerializeField] [RequireInterface(typeof(ISkillType))]
        private ScriptableObject _skillType;

        public ISkillType SkillType
        {
            get => _skillType as ISkillType;
            set => _skillType = value as ScriptableObject;
        }

        [SerializeField] [RequireInterface(typeof(ISkillEnabledStatus))]
        private ScriptableObject _skillEnabledStatus;

        public ISkillEnabledStatus SkillEnabledStatus
        {
            get => _skillEnabledStatus as ISkillEnabledStatus;
            set => _skillEnabledStatus = value as ScriptableObject;
        }



        [SerializeField] [RequireInterface(typeof(ISkillTarget))]
        private ScriptableObject _skillTarget;

        public ISkillTarget SkillTarget
        {
            get => _skillTarget as ISkillTarget;
            set => _skillTarget = value as ScriptableObject;
        }
        
        [SerializeField] [RequireInterface(typeof(ISkillReadiness))]
        private ScriptableObject _skillReadiness;

        public ISkillReadiness SkillReadiness
        {
            get => _skillReadiness as ISkillReadiness;
            set => _skillReadiness = value as ScriptableObject;
        }
        
        [SerializeField] [RequireInterface(typeof(ISkillUseStatusAsset))]
        private ScriptableObject _skillUseStatus;

        public ISkillUseStatusAsset SkillUseStatus
        {
            get => _skillUseStatus as ISkillUseStatusAsset;
            set => _skillUseStatus = value as ScriptableObject;
        }

        [SerializeField]
        private Object skillEffectAsset;

        public ISkillEffectAsset SkillEffectAsset
        {
            get => skillEffectAsset as ISkillEffectAsset;
            set => skillEffectAsset = value as Object;
        }
        
        //Test
        private ISkillLogic _skillLogic;

        public ISkill SkillReference => _skillLogic.Skill;

        [SerializeField] private ScriptableObject skillCooldownType;

        public ISkillCooldownTypeAsset SkillCooldownType
        {
            get => skillCooldownType as ISkillCooldownTypeAsset;
            set => skillCooldownType = value as ScriptableObject;
        }

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
           
        }


        


    }
}
