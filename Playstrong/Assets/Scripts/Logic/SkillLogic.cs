﻿using System;
using Interfaces;
using References;
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
        
        private IReduceSkillCooldown _reduceSkillCooldown;

        private ISkill _skill;
        public ISkill Skill => _skill;

        private void Awake()
        {
            _reduceSkillCooldown = GetComponent<IReduceSkillCooldown>();
            _skill = GetComponentInParent<ISkill>();

        }
    }
}
