using System;
using UnityEngine;

namespace Logic
{
    public class UpdateStatusEffectCounters : MonoBehaviour
    {

        private IHeroStatusEffects _heroStatusEffects;
        private int _value = 1;
        private void Awake()
        {
            _heroStatusEffects = GetComponent<IHeroStatusEffects>();
        }

        public void UpdateCounters()
        {
            //Hero Buffs
            foreach (var statusEffect in _heroStatusEffects.HeroBuffEffects.HeroBuffs)
            {
                //TODO: Replace this with the StatusEffectCounterTiming SO
                statusEffect.ReduceStatusEffectCounters.ReduceCounters(_value, statusEffect.CoroutineTreesAsset);
            }
            
            //Hero Debuffs
            foreach (var statusEffect in _heroStatusEffects.HeroDebuffEffects.HeroDebuffs)
            {
                //TODO: Replace this with the StatusEffectCounterTiming SO
                statusEffect.ReduceStatusEffectCounters.ReduceCounters(_value, statusEffect.CoroutineTreesAsset);
            }
        }
        
        
        
    }
}
