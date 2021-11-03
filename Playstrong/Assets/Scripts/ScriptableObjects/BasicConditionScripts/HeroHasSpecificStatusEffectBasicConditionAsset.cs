using System.Collections;
using System.Collections.Generic;
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

            foreach (var statusEffect in allBuffs)
            {
                return statusEffect.Name == StatusEffectAsset.Name ? 1 : 0;
            }
            
            foreach (var statusEffect in allDebuffs)
            {
                return statusEffect.Name == StatusEffectAsset.Name ? 1 : 0;
            }
            
            foreach (var statusEffect in allUniqueEffects)
            {
                return statusEffect.Name == StatusEffectAsset.Name ? 1 : 0;
            }

            return 0;
        }

       

        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var allBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var allDebuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var allUniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;

            foreach (var statusEffect in allBuffs)
            {
                return statusEffect.Name == StatusEffectAsset.Name ? 1 : 0;
            }
            
            foreach (var statusEffect in allDebuffs)
            {
                return statusEffect.Name == StatusEffectAsset.Name ? 1 : 0;
            }
            
            foreach (var statusEffect in allUniqueEffects)
            {
                return statusEffect.Name == StatusEffectAsset.Name ? 1 : 0;
            }

            return 0;
        }
        
       
   



    }
}
