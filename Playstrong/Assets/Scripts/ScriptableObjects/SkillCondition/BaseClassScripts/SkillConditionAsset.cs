using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Others;
using ScriptableObjects.SkillActions.BaseClassScripts;
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
        [RequireInterface(typeof(ISkillActionAsset))]
        private List<Object> _skillActionAssets = new List<Object>();

        public List<ISkillActionAsset> SkillActionAssets
        {
            get
            {
                var skillActions = new List<ISkillActionAsset>();
                foreach (var skillActionAssetObject in _skillActionAssets)
                {
                    var skillAction = skillActionAssetObject as ISkillActionAsset;
                    skillActions.Add(skillAction);
                }

                return skillActions;

            }
            
        }

        /// <summary>
        /// Run all skill actions assigned to the skill condition
        /// </summary>
        /// <param name="hero"></param>
        public virtual void Target(IHero hero)
        {
            _logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
           _logicTree.AddCurrent(TargetCoroutine(hero));
        }

        private IEnumerator TargetCoroutine(IHero hero)
        {
            var skillActions = SkillActionAssets;
            foreach (var skillAction in skillActions)
            {
                skillAction.Target(hero);   
            }
            
            _logicTree.EndSequence();
            yield return null;
        }

        


    }
}
