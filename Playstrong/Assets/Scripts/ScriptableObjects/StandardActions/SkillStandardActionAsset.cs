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
        
        /// <summary>
        /// Checks if skill is ready before executing start action
        /// </summary>
        /// <param name="targetHero"></param>
        public override void StartAction(IHero targetHero)
        {
            _skillReference.SkillLogic.SkillAttributes.SkillReadiness.SkillStartAction(this,targetHero);

            //SkillStartActionCoroutines(targetHero);
        }
        
        /// <summary>
        /// Checks if skill is ready before executing start action
        /// </summary>
        public override void StartAction(IHero thisHero, IHero targetHero)
        {
            _skillReference.SkillLogic.SkillAttributes.SkillReadiness.SkillStartAction(this,thisHero,targetHero);
            
            //SkillStartActionCoroutines(thisHero, targetHero);
        }

        public void SetSkillReference(ISkill skill)
        {
            _skillReference = skill;
           //Debug.Log("Set Skill Reference: " +_skillReference.SkillName);
        }
        
        
        
        
        /// <summary>
        /// Start action coroutine executed when skillReadiness is SkillReady
        /// </summary>
        public void SkillStartActionCoroutines(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SetUsingPassiveSkillStatus());
            logicTree.AddCurrent(StartActionCoroutine(thisHero,targetHero));
            logicTree.AddCurrent(SetHeroUsedPassiveSkill());
        }
        
        /// <summary>
        /// Start action coroutine executed when skillReadiness is SkillReady
        /// </summary>
        public void SkillStartActionCoroutines(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SetUsingPassiveSkillStatus());
            logicTree.AddCurrent(StartActionCoroutine(targetHero));
            logicTree.AddCurrent(SetHeroUsedPassiveSkill());
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
