using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Enums;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillCooldown : MonoBehaviour, IUpdateSkillCooldown
    {
        private ISkillLogic _skillLogic;
        private ISkill _skill;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
            _skill = _skillLogic.Skill;
        }
        
        /// <summary>
        /// Should only be used by TurnController in Hero Active/Inactive phases
        /// </summary>
        public IEnumerator TurnReduceCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.TurnReduceCooldown(_skill, counter));
            
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator IncreaseCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.IncreaseCooldown(_skill, counter));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Used by Refresh and Reset Basic Actions
        /// </summary>
        public IEnumerator SetSkillCdToValue(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.SetSkillCdToValue(_skill, counter));
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Should only be used by TurnController in Hero Active/Inactive phases
        /// </summary>
        public IEnumerator TurnResetCooldownToMax()
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.TurnResetCooldownToMax(_skill));
            
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator RefreshCooldownToZero()
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.RefreshCooldownToZero(_skill));
            
            logicTree.EndSequence();
            yield return null;
        }

    }
}
