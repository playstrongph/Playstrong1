using System;
using System.CodeDom;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class UpdateSkillUseStatus : MonoBehaviour, IUpdateSkillUseStatus
    {
        [SerializeField] [RequireInterface(typeof(ISkillUseStatusAsset))]
        private ScriptableObject usingSkill;
        private ISkillUseStatusAsset UsingSkill => usingSkill as ISkillUseStatusAsset;
        
        [SerializeField] [RequireInterface(typeof(ISkillUseStatusAsset))]
        private ScriptableObject notUsingSkill;
        private ISkillUseStatusAsset NotUsingSkill => notUsingSkill as ISkillUseStatusAsset;

        [SerializeField] [RequireInterface(typeof(ISkillUseStatusAsset))]
        private ScriptableObject usedLastTurnSkill;
        private ISkillUseStatusAsset UsedLastTurnSkill => usedLastTurnSkill as ISkillUseStatusAsset;

        private ISkillLogic _skillLogic;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

        public void SetUsingSkillStatus()
        {
            _skillLogic.SkillAttributes.SkillUseStatus = UsingSkill;
           
        }

        public void SetNotUsingSkillStatus()
        {
            _skillLogic.SkillAttributes.SkillUseStatus = NotUsingSkill;
           
        }
        
        //TEST
        public void SetUsedLastTurnSkillStatus()
        {
            _skillLogic.SkillAttributes.SkillUseStatus = UsedLastTurnSkill;
           
        }

    }
}
