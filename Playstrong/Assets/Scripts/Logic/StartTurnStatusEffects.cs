using UnityEngine;

namespace Logic
{
    public class StartTurnStatusEffects : MonoBehaviour, IStartTurnStatusEffects
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
                statusEffect.StatusEffectAsset.StartTurnStatusEffect(statusEffect.Hero);
            }
            
            //Hero Debuffs
            foreach (var statusEffect in _heroStatusEffects.HeroDebuffEffects.HeroDebuffs)
            {
                statusEffect.StatusEffectAsset.StartTurnStatusEffect(statusEffect.Hero);
            }
        }
    }
}
