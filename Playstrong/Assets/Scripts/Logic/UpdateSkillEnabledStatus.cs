using System;
using Interfaces;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillEnabledStatus : MonoBehaviour, IUpdateSkillEnabledStatus
    {

        [SerializeField] private ScriptableObject skillEnabledAsset;
        public ISkillEnabledStatus SkillEnabled => skillEnabledAsset as ISkillEnabledStatus;
        
        [SerializeField] private ScriptableObject skillDisabledAsset;
        public ISkillEnabledStatus SkillDisabled => skillDisabledAsset as ISkillEnabledStatus;

    }
}
