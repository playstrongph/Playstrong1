using System;
using Interfaces;
using References;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using ScriptableObjects.SkillEffects;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;

namespace Logic
{
    public class SkillLogic : MonoBehaviour, ISkillLogic
    {
        [SerializeField]
        [RequireInterface(typeof(ISkillAttributes))]
        private Object _skillAttributes;
        public ISkillAttributes SkillAttributes => _skillAttributes as ISkillAttributes;


        [SerializeField]
        [RequireInterface(typeof(ILoadSkillAttributes))]
        private Object _loadSkillAttributes;
        public ILoadSkillAttributes LoadSkillAttributes => _loadSkillAttributes as ILoadSkillAttributes;

        private ISkill _skill;
        public ISkill Skill => _skill;

        private IUpdateSkillReadiness _updateSkillReadiness;
        public IUpdateSkillReadiness UpdateSkillReadiness => _updateSkillReadiness;

        private ISkillEvents _skillEvents;
        public ISkillEvents SkillEvents => _skillEvents;

        private IChangeSkillCooldown _changeSkillCooldown;
        public IChangeSkillCooldown ChangeSkillCooldown => _changeSkillCooldown;

        private ISkillAttack _skillAttack;
        public ISkillAttack SkillAttack => _skillAttack;

        private IUpdateSkillEnabledStatus _updateSkillEnabledStatus;
        public IUpdateSkillEnabledStatus UpdateSkillEnabledStatus => _updateSkillEnabledStatus;
        
        

        private void Awake()
        {
            _skill = GetComponentInParent<ISkill>();
            _updateSkillReadiness = GetComponent<IUpdateSkillReadiness>();
            _skillEvents = GetComponent<ISkillEvents>();
            _changeSkillCooldown = GetComponent<IChangeSkillCooldown>();
            _skillAttack = GetComponent<ISkillAttack>();
            _updateSkillEnabledStatus = GetComponent<IUpdateSkillEnabledStatus>();

        }
    }
}
