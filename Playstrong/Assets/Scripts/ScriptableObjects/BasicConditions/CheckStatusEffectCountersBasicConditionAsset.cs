﻿using System.Collections;
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
            if (StatusEffectReference.Counters <= counters)
                return 0;
            else
                return 1;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            if (StatusEffectReference.Counters <= counters)
                return 0;
            else
                return 1;
        }
   



    }
}
