using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    
    /// <summary>
    /// All Conditions need to be implemented in 3 different types of arguments:
    /// 1) targetHero 2) thisHero,targetHero 3) targetHero, value
    /// </summary>
    public class BasicConditionAsset : ScriptableObject, IBasicConditionAsset
    {
       
        /// <summary>
        /// Returns a value of 1 if basic condition is met, 0 otherwise;
        /// Default value is zero
        /// </summary>
        public int GetValue(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var value = CheckBasicCondition(thisHero,targetHero);
            
            return value;
        }
        
        protected virtual int CheckBasicCondition(IHero thisHero, IHero targetHero)
        {
            var x = 0;
            return x;
        }
        
        public int GetValue(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var value = CheckBasicCondition(thisHero);
            
            return value;
        }
        
        protected virtual int CheckBasicCondition(IHero thisHero)
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

        
        
        
        
    }
}
