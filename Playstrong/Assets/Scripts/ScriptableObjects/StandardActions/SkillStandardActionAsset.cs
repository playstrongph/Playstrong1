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
            
            logicTree.AddCurrent(SetUsingSkillStatus());
            
            logicTree.AddCurrent(StartActionCoroutine(targetHero));

            logicTree.AddCurrent(SetUsedLastTurnSkillStatus());
        }
        
        public override void StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SetUsingSkillStatus());
            //Has to be Coroutine to ensure GetHeroTargets are taken at the right time
            logicTree.AddCurrent(StartActionCoroutine(thisHero,targetHero));
            
            logicTree.AddCurrent(SetUsedLastTurnSkillStatus());
        }

        public void SetSkillReference(ISkill skill)
        {
            _skillReference = skill;
           //Debug.Log("Set Skill Reference: " +_skillReference.SkillName);
        }
        
        
        private IEnumerator SetUsingSkillStatus()
        {
            //Debug.Log("Set Using Skill Status: " +_skillReference.SkillName);
            var logicTree = _skillReference.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _skillReference.SkillLogic.UpdateSkillUseStatus.SetUsingSkillStatus();
            
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator SetUsedLastTurnSkillStatus()
        {
            //Debug.Log("SetUsedLastTurnSkillStatus: " +_skillReference.SkillName);
            var logicTree = _skillReference.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _skillReference.SkillLogic.UpdateSkillUseStatus.SetUsedLastTurnSkillStatus();
            
            logicTree.EndSequence();
            yield return null;
        }

    }

    
}
