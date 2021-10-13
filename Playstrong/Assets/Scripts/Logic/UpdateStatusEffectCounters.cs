using System;
using UnityEngine;

namespace Logic
{
    public class UpdateStatusEffectCounters : MonoBehaviour, IUpdateStatusEffectCounters
    {

        private IHeroStatusEffects _heroStatusEffects;
        private int _value = 1;
        private void Awake()
        {
            _heroStatusEffects = GetComponent<IHeroStatusEffects>();
        }

        public void UpdateCountersStartTurn()
        {
            
            //Hero Buffs
            foreach (var statusEffect in _heroStatusEffects.HeroBuffEffects.HeroBuffs)
            {
                statusEffect.StatusEffectUpdateTiming.UpdateCountersStartTurn(statusEffect);
            }
            
            //Hero Debuffs
            foreach (var statusEffect in _heroStatusEffects.HeroDebuffEffects.HeroDebuffs)
            {
                statusEffect.StatusEffectUpdateTiming.UpdateCountersStartTurn(statusEffect);
            }
        }
        
        public void UpdateCountersEndTurn()
        {
            //Hero Buffs
            foreach (var statusEffect in _heroStatusEffects.HeroBuffEffects.HeroBuffs)
            {
                statusEffect.StatusEffectUpdateTiming.UpdateCountersEndTurn(statusEffect);
            }
            
            //Hero Debuffs
            foreach (var statusEffect in _heroStatusEffects.HeroDebuffEffects.HeroDebuffs)
            {
                statusEffect.StatusEffectUpdateTiming.UpdateCountersEndTurn(statusEffect);
            }
        }
        
        
        
    }
}
