using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillEffects
{
   
    [CreateAssetMenu(fileName = "SkillEffectAsset", menuName = "SO's/SkillEffect/SkillEffectAsset")]
    public class SkillEffectAsset : ScriptableObject, ISkillEffectAsset
    {
        
       
        
        [SerializeField]
        [RequireInterface(typeof(ISkillConditionAsset))]
        private List<Object> _skillConditionAssets = new List<Object>();

        public List<ISkillConditionAsset> SkillConditionAssets
        {
            get
            {
                var skillConditions = new List<ISkillConditionAsset>();
                foreach (var skillConditionAssetObject in _skillConditionAssets)
                {
                    var skillCondition = skillConditionAssetObject as ISkillConditionAsset;
                    skillConditions.Add(skillCondition);
                }

                return skillConditions;

            }
            
        }
        
        public void UseSkillEffect(IHero hero, ICoroutineTreesAsset coroutineTreesAsset)
        {
            var logicTree = coroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(UseSkillEffectCoroutine(hero, coroutineTreesAsset));
            
        }

        private IEnumerator UseSkillEffectCoroutine(IHero hero, ICoroutineTreesAsset coroutineTreesAsset)
        {
            var logicTree = coroutineTreesAsset.MainLogicTree;
            
            foreach (var skillCondition in SkillConditionAssets )
            {
                skillCondition.Target(hero, coroutineTreesAsset);
            }
            
            logicTree.EndSequence();
            yield return null;
            
        }






    }
}
