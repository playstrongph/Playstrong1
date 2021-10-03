﻿using System;
using Interfaces;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillEnabledStatus : MonoBehaviour, IUpdateSkillEnabledStatus
    {

        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

        [SerializeField] private ScriptableObject skillEnabledAsset;
        public ISkillEnabledStatus SkillEnabled => skillEnabledAsset as ISkillEnabledStatus;
        
        [SerializeField] private ScriptableObject skillDisabledAsset;
        public ISkillEnabledStatus SkillDisabled => skillDisabledAsset as ISkillEnabledStatus;

        public void SetSkillDisabledStatus()
        {
            _s
        }
        
        public void SetSkillEnabledStatus()
        {
            
        }

    }
}
