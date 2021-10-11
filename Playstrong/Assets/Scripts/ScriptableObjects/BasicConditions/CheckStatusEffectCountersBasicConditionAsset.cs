using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "CheckStatusEffectCounters", menuName = "SO's/BasicConditions/CheckStatusEffectCounters")]
    
    public class CheckStatusEffectCountersBasicConditionAsset : BasicConditionAsset
    {
        [SerializeField] private int counters;
        
        public override int GetValue(IStatusEffectAsset statusEffect)
        {
            var value = CheckBasicCondition(statusEffect);
            
            return value;
        }
        
        protected override int CheckBasicCondition(IStatusEffectAsset statusEffect)
        {
            var x = 0;
            return x;
        }
   



    }
}
