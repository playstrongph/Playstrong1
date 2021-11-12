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

        public void SetHeroUsingPassiveSkill()
        {
            //TODO: Should check skilltype - Active, CDPassive, and Passive
            //_skillLogic.SkillAttributes.SkillUseStatus = UsingSkill;

            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree; 
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillType.HeroUsingPassiveSkill(_skillLogic.Skill));

        }

        public void SetHeroUsedPassiveSkill()
        {
            //TODO: Should check skilltype - Active, CDPassive, and Passive
            //_skillLogic.SkillAttributes.SkillUseStatus = UsedLastTurnSkill;
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree; 
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillType.HeroUsedPassiveSkill(_skillLogic.Skill));
           
        }
        
        //Used by both Passive and Active Skills
        public void SetHeroNotUsingSkill()
        {
            _skillLogic.SkillAttributes.SkillUseStatus = NotUsingSkill;
           
        }
        
        
        //TEST NEW - Nov 11 2021
        
        public void SetUsingSkill()
        {
            _skillLogic.SkillAttributes.SkillUseStatus = UsingSkill;
           
        }
        
        public void SetUsedSkillLastTurn()
        {
            //TODO: Should check skilltype - Active, CDPassive, and Passive
            _skillLogic.SkillAttributes.SkillUseStatus = UsedLastTurnSkill;
           
        }

    }
}
