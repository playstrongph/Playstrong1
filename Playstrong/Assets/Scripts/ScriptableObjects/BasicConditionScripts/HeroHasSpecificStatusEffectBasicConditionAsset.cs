using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "HeroHasSpecificStatusEffect", menuName = "SO's/BasicConditions/HeroHasSpecificStatusEffect")]
    
    public class HeroHasSpecificStatusEffectBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private ScriptableObject statusEffectAsset;
        private IStatusEffectAsset StatusEffectAsset => statusEffectAsset as IStatusEffectAsset;

        private IHeroStatusEffect _specificStatusEffect;

        protected override int CheckBasicCondition(IHero targetHero)
        {
            var allBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var allDebuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var allUniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;

            _specificStatusEffect = ResetSpecificStatusEffect();
            
            foreach (var statusEffect in allBuffs)
            {
                if (statusEffect.Name == StatusEffectAsset.Name)
                    _specificStatusEffect = statusEffect;
            }
            
            foreach (var statusEffect in allDebuffs)
            {
                if (statusEffect.Name == StatusEffectAsset.Name)
                    _specificStatusEffect = statusEffect;
            }
            
            foreach (var statusEffect in allUniqueEffects)
            {
                if (statusEffect.Name == StatusEffectAsset.Name)
                    _specificStatusEffect = statusEffect;
            }

            return _specificStatusEffect != null ? 1 : 0;
        }

       

        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var allBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var allDebuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var allUniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;

            _specificStatusEffect = ResetSpecificStatusEffect();
            
            foreach (var statusEffect in allBuffs)
            {
                if (statusEffect.Name == StatusEffectAsset.Name)
                    _specificStatusEffect = statusEffect;
            }
            
            foreach (var statusEffect in allDebuffs)
            {
                if (statusEffect.Name == StatusEffectAsset.Name)
                    _specificStatusEffect = statusEffect;
            }
            
            foreach (var statusEffect in allUniqueEffects)
            {
                if (statusEffect.Name == StatusEffectAsset.Name)
                    _specificStatusEffect = statusEffect;
            }

            return _specificStatusEffect != null ? 1 : 0;
        }
        
        /// <summary>
        /// Resets the status effect back to null
        /// since this is a scriptable object
        /// </summary>
        /// <returns></returns>
        private IHeroStatusEffect ResetSpecificStatusEffect()
        {
            return null;
        }
   



    }
}
