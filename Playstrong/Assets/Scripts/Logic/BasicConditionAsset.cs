using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace Logic
{
    
    /// <summary>
    /// All Conditions need to be implemented in 3 different types of arguments:
    /// 1) targetHero 2) thisHero,targetHero 3) targetHero, value
    /// </summary>
    public class BasicConditionAsset : ScriptableObject, IBasicConditionAsset
    {
        //Reference
        public IHeroStatusEffect StatusEffectReference { get; set; }

        public ISkill SkillReference { get; set; }


        /// <summary>
        /// Returns a value of 1 if basic condition is met, 0 otherwise;
        /// Default value is zero
        /// </summary>
        public int GetValue(IHero thisHero)
        {
            //Debug.Log("Get Basic Condition Value");
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            //var value = CheckBasicCondition(thisHero);
            
            return  CheckBasicCondition(thisHero);
        }
        
        protected virtual int CheckBasicCondition(IHero thisHero)
        {
            var x = 0;
            return x;
        }

        public int GetValue(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Get Basic Condition Value");
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            //var value = CheckBasicCondition(thisHero,targetHero);
            
            return CheckBasicCondition(thisHero,targetHero);
        }
        
        protected virtual int CheckBasicCondition(IHero thisHero, IHero targetHero)
        {
            var x = 0;
            return x;
        }
        
      
        public int GetValue(IHero thisHero, float amount)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var value = CheckBasicCondition(thisHero,amount);
            
            return value;
        }
        
        protected virtual int CheckBasicCondition(IHero thisHero,float amount)
        {
            var x = 0;
            return x;
        }
        
        public virtual int GetValue(IStatusEffectAsset statusEffect)
        {
            var value = CheckBasicCondition(statusEffect);
            
            return value;
        }
        
        protected virtual int CheckBasicCondition(IStatusEffectAsset statusEffect)
        {
            var x = 0;
            return x;
        }

        
        
        
        
    }
}
