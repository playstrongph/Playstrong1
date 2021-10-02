using System;
using Interfaces;
using References;
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

        private IUpdateSkillReadiness _skillReadiness;
        public IUpdateSkillReadiness SkillReadiness => _skillReadiness;

        private ISkillEvents _skillEvents;
        public ISkillEvents SkillEvents => _skillEvents;

        private IChangeSkillCooldown _changeSkillCooldown;
        public IChangeSkillCooldown ChangeSkillCooldown => _changeSkillCooldown;

        private ISkillAttack _skillAttack;
        public ISkillAttack SkillAttack => _skillAttack;
        
        

        private void Awake()
        {
            _skill = GetComponentInParent<ISkill>();
            _skillReadiness = GetComponent<IUpdateSkillReadiness>();
            _skillEvents = GetComponent<ISkillEvents>();
            _changeSkillCooldown = GetComponent<IChangeSkillCooldown>();
            _skillAttack = GetComponent<ISkillAttack>();

        }
    }
}
