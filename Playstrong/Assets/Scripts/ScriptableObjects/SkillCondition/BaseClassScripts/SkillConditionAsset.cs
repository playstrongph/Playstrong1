﻿using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillCondition.BaseClassScripts
{
   
    
    public class SkillConditionAsset : ScriptableObject,ISkillConditionAsset
    {

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        private ICoroutineTreesAsset _coroutineTreesAsset;
        
        [SerializeField]
        [RequireInterface(typeof(IHeroAction))]
        private List<Object> _skillActionAssets = new List<Object>();

        public List<IHeroAction> SkillActionAssets
        {
            get
            {
                var skillActions = new List<IHeroAction>();
                foreach (var skillActionAssetObject in _skillActionAssets)
                {
                    var skillAction = skillActionAssetObject as IHeroAction;
                    skillActions.Add(skillAction);
                }

                return skillActions;

            }
            
        }
        
        //TEST
        public ISkillStatus SkillReadinessReference { get; set; }

        public ISkillAttributes SkillAttributes { get; set; }
        //TEST END

        /// <summary>
        /// Run all skill actions assigned to the skill condition
        /// </summary>
        /// <param name="hero"></param>
        public virtual void Target(IHero thisHero, IHero targetHero)
        {
            _logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
           _logicTree.AddCurrent(TargetCoroutine(thisHero, targetHero));
        }

        private IEnumerator TargetCoroutine(IHero thisHero, IHero targetHero)
        {
            var skillActions = SkillActionAssets;
            foreach (var skillAction in skillActions)
            {
                //skillAction.Target(hero);   
                //_logicTree.AddCurrent(skillAction.StartAction(thisHero, targetHero));
                
                //SkillReadinessReference.StartAction(skillAction,thisHero,targetHero);
                
                SkillAttributes.SkillStatus.StartAction(skillAction,thisHero,targetHero);
            }   
            
            _logicTree.EndSequence();
            yield return null;
        }

        


    }
}
