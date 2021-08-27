using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
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
        
      
        public ISkillAttributes SkillAttributes { get; set; }
       

        /// <summary>
        /// Run all skill actions assigned to the skill condition
        /// </summary>
        public virtual void UseSkillAction(IHero thisHero, IHero targetHero)
        {
            _logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
           _logicTree.AddCurrent(UseSkillActionCoroutine(thisHero, targetHero));
        }

        private IEnumerator UseSkillActionCoroutine(IHero thisHero, IHero targetHero)
        {
            var skillActions = SkillActionAssets;
            foreach (var skillAction in skillActions)
            {
                SkillAttributes.SkillStatus.StartAction(skillAction,thisHero,targetHero);  //Checks Skill Readiness before calling start action
            }   
            
            SkillAttributes.SkillType.ResetSkillCd(SkillAttributes.SkillReference);
            
            
            _logicTree.EndSequence();
            yield return null;
        }

        


    }
}
