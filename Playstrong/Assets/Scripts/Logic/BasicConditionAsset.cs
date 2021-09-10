using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class BasicConditionAsset : ScriptableObject
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

        
        
        
        
    }
}
