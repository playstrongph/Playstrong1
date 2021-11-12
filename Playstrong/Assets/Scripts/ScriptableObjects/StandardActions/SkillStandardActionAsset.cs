using System.Collections;
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
            
           
            //logicTree.AddCurrent(SetUsingPassiveSkillStatus());
            //logicTree.AddCurrent(StartActionCoroutine(targetHero));
            //logicTree.AddCurrent(SetHeroUsedPassiveSkill());
            
            var skillReady = _skillReference.SkillLogic.UpdateSkillReadiness.SkillReady;
            var skillReadinessStatus = _skillReference.SkillLogic.SkillAttributes.SkillReadiness;
            if (skillReadinessStatus == skillReady)
            {
                logicTree.AddCurrent(SetUsingPassiveSkillStatus());
                logicTree.AddCurrent(StartActionCoroutine(targetHero));
                logicTree.AddCurrent(SetHeroUsedPassiveSkill());
            }
            
            
            
            
        }
        
        public override void StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            //TEST Nov 12 2021
            //logicTree.AddCurrent(SetUsingPassiveSkillStatus());
            //logicTree.AddCurrent(StartActionCoroutine(thisHero,targetHero));
            //logicTree.AddCurrent(SetHeroUsedPassiveSkill());
            
            var skillReady = _skillReference.SkillLogic.UpdateSkillReadiness.SkillReady;
            var skillReadinessStatus = _skillReference.SkillLogic.SkillAttributes.SkillReadiness;
            if (skillReadinessStatus == skillReady)
            {
                logicTree.AddCurrent(SetUsingPassiveSkillStatus());
                logicTree.AddCurrent(StartActionCoroutine(thisHero,targetHero));
                logicTree.AddCurrent(SetHeroUsedPassiveSkill());
            }

            
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
            
            //TEST Nov 12 2021
            _skillReference.SkillLogic.SkillAttributes.SkillType.ResetCdPassiveSkillCd(_skillReference);
            
            logicTree.EndSequence();
            yield return null;
        }

       

    }

    
}
