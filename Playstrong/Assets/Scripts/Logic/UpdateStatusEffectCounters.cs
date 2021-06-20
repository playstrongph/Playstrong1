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

        public void UpdateCountersStartTurn()
        {
            //Hero Buffs
            foreach (var statusEffect in _heroStatusEffects.HeroBuffEffects.HeroBuffs)
            {
                statusEffect.StatusEffectCounterUpdate.UpdateCountersStartTurn(statusEffect);
            }
            
            //Hero Debuffs
            foreach (var statusEffect in _heroStatusEffects.HeroDebuffEffects.HeroDebuffs)
            {
                statusEffect.StatusEffectCounterUpdate.UpdateCountersStartTurn(statusEffect);
            }
        }
        
        public void UpdateCountersEndTurn()
        {
            //Hero Buffs
            foreach (var statusEffect in _heroStatusEffects.HeroBuffEffects.HeroBuffs)
            {
                statusEffect.StatusEffectCounterUpdate.UpdateCountersEndTurn(statusEffect);
            }
            
            //Hero Debuffs
            foreach (var statusEffect in _heroStatusEffects.HeroDebuffEffects.HeroDebuffs)
            {
                statusEffect.StatusEffectCounterUpdate.UpdateCountersEndTurn(statusEffect);
            }
        }
        
        
        
    }
}
