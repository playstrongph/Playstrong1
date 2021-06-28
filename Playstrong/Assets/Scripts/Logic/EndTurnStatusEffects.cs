using UnityEngine;

namespace Logic
{
    public class EndTurnStatusEffects : MonoBehaviour, IEndTurnStatusEffects
    {
        private IHeroStatusEffects _heroStatusEffects;
        
        private void Awake()
        {
            _heroStatusEffects = GetComponent<IHeroStatusEffects>();
        }

        public void TriggerStatusEffect()
        {
            foreach (var statusEffect in _heroStatusEffects.HeroBuffEffects.HeroBuffs)
            {
                statusEffect.StatusEffectAsset.EndTurnStatusEffect(statusEffect.Hero);
            }
            
            //Hero Debuffs
            foreach (var statusEffect in _heroStatusEffects.HeroDebuffEffects.HeroDebuffs)
            {
                statusEffect.StatusEffectAsset.EndTurnStatusEffect(statusEffect.Hero);
            }
        }
    }
}
