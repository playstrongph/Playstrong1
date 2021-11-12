﻿using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.GameEvents;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScriptableObjects.StandardActions
{
    [CreateAssetMenu(fileName = "SkillStandardAction", menuName = "SO's/StandardActions/SkillStandardAction")]
    public class SkillStandardActionAsset : StandardActionAsset, ISkillStandardActionAsset
    {

        private ISkill _skillReference;
        
        public override void StartAction(IHero targetHero)
        {
            //Debug.Log("" +this.name  +" StartAction targetHero");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: ActiveSkillTransfer to DragSkillTargetEvent
            logicTree.AddCurrent(SetUsingPassiveSkillStatus());
            
            logicTree.AddCurrent(StartActionCoroutine(targetHero));

            logicTree.AddCurrent(SetHeroUsedPassiveSkill());
        }
        
        public override void StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            
            logicTree.AddCurrent(SetUsingPassiveSkillStatus());
            
            //Has to be Coroutine to ensure GetHeroTargets are taken at the right time
            logicTree.AddCurrent(StartActionCoroutine(thisHero,targetHero));
            
            logicTree.AddCurrent(SetHeroUsedPassiveSkill());
        }

        public void SetSkillReference(ISkill skill)
        {
            _skillReference = skill;
           //Debug.Log("Set Skill Reference: " +_skillReference.SkillName);
        }
        
        
        private IEnumerator SetUsingPassiveSkillStatus()
        {
            Debug.Log("Set Using Skill Status: " +_skillReference.SkillName);
            var logicTree = _skillReference.Hero.CoroutineTreesAsset.MainLogicTree;
            
           
            _skillReference.SkillLogic.UpdateSkillUseStatus.SetHeroUsingPassiveSkill();
            
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator SetHeroUsedPassiveSkill()
        {
            Debug.Log("SetUsedLastTurnSkillStatus: " +_skillReference.SkillName);
            var logicTree = _skillReference.Hero.CoroutineTreesAsset.MainLogicTree;
            
           
            _skillReference.SkillLogic.UpdateSkillUseStatus.SetHeroUsedPassiveSkill();
            
            logicTree.EndSequence();
            yield return null;
        }

    }

    
}
