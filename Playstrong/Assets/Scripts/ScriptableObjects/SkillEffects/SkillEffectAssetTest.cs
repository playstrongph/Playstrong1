using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.GameEvents;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using ScriptableObjects.StandardActions;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace ScriptableObjects.SkillEffects
{
   
    [CreateAssetMenu(fileName = "SkillEffectAssetTest", menuName = "SO's/SkillEffect/SkillEffectAssetTest")]
    public class SkillEffectAssetTest : ScriptableObject, ISkillEffectAsset
    {

        [SerializeField] private List<ScriptableObject> standardActions;
        
        public List<ScriptableObject> StandardActionsObjects => standardActions;
        public List<IStandardActionAsset> StandardActions
        {
            get
            {
                var newStandardActions = new List<IStandardActionAsset>();
                foreach (var standardActionObject in standardActions)
                {
                    var standardAction = standardActionObject as IStandardActionAsset;
                    newStandardActions.Add(standardAction);
                }

                return newStandardActions;
            }
        }


        public void RegisterSkillEffect(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;

            foreach (var standardAction in StandardActions)
            {
                logicTree.AddCurrent(standardAction.RegisterStandardAction(skill));
               
            }
        }
        
        public void RegisterSkillEffect(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            foreach (var standardAction in StandardActions)
            {
                logicTree.AddCurrent(standardAction.RegisterStandardAction(thisHero));
               
            }
        }
        
        public void UnregisterSkillEffect(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardAction in StandardActions)
            {
                logicTree.AddCurrent(standardAction.UnregisterStandardAction(skill));
            }
           
        }
        
        public void UnregisterSkillEffect(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            foreach (var standardAction in StandardActions)
            {
                logicTree.AddCurrent(standardAction.UnregisterStandardAction(thisHero));
            }
        }

    }
}
