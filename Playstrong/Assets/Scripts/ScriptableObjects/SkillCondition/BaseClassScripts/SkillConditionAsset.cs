using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Actions.BaseClassScripts;
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

        private List<IHeroAction> SkillActionAssets
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
        
        public ISkill ReferenceSkill { get; set; }

        /// <summary>
        /// Run all skill actions assigned to the skill condition
        /// </summary>
        /// <param name="hero"></param>
        public virtual void Target(IHero thisHero, IHero targetHero)
        {
            _logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TEST
            //TODO:  Check either skill cooldown <=0 or skill readiness here
            //if(ReferenceSkill.SkillLogic.SkillAttributes.Cooldown <= 0)
                _logicTree.AddCurrent(TargetCoroutine(thisHero, targetHero));
        }

        private IEnumerator TargetCoroutine(IHero thisHero, IHero targetHero)
        {
            var skillActions = SkillActionAssets;
            foreach (var skillAction in skillActions)
            {
                
                _logicTree.AddCurrent(skillAction.StartAction(thisHero, targetHero));
            }
            
            _logicTree.EndSequence();
            yield return null;
        }

        


    }
}
