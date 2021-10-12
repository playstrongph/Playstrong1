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

        protected override int CheckBasicCondition(IHero thisHero)
        {
            Debug.Log("Bomb Status Effect Counters: " +StatusEffectReference.Counters +" Limit: " +counters);
            if (StatusEffectReference.Counters <= counters)
            {
                Debug.Log("Return 1");
                return 1;    
            }
            else
            {
                Debug.Log("Return 0");
                return 0;    
            }

            
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            Debug.Log("Bomb Status Effect Counters: " +StatusEffectReference.Counters);
            if (StatusEffectReference.Counters <= counters)
            {
                Debug.Log("Return 1");
                return 1;    
            }
            else
            {
                Debug.Log("Return 0");
                return 0;    
            }
        }
   



    }
}
