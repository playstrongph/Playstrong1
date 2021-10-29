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

        [SerializeField] private ScriptableObject statusEffectAssetCheck;
        private IStatusEffectAsset StatusEffectAssetCheck => statusEffectAssetCheck as IStatusEffectAsset;

        private IHeroStatusEffect _statusEffectCheck;

        protected override int CheckBasicCondition(IHero targetHero)
        {
            var heroDebuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var heroBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var heroUniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;
            
            foreach (var debuff in heroDebuffs)
            {
                if (debuff.Name == StatusEffectAssetCheck.Name)
                    _statusEffectCheck = debuff;
            }
            
            foreach (var buff in heroBuffs)
            {
                if (buff.Name == StatusEffectAssetCheck.Name)
                    _statusEffectCheck = buff;
            }
            
            foreach (var uniqueEffect in heroUniqueEffects)
            {
                if (uniqueEffect.Name == StatusEffectAssetCheck.Name)
                    _statusEffectCheck = uniqueEffect;
            }


            if (_statusEffectCheck != null)
            {
                return _statusEffectCheck.Counters <= counters ? 1 : 0;
            }
            else
            {
                return 0;
            }
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var heroDebuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var heroBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var heroUniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;
            
            foreach (var debuff in heroDebuffs)
            {
                if (debuff.Name == StatusEffectAssetCheck.Name)
                    _statusEffectCheck = debuff;
            }
            
            foreach (var buff in heroBuffs)
            {
                if (buff.Name == StatusEffectAssetCheck.Name)
                    _statusEffectCheck = buff;
            }
            
            foreach (var uniqueEffect in heroUniqueEffects)
            {
                if (uniqueEffect.Name == StatusEffectAssetCheck.Name)
                    _statusEffectCheck = uniqueEffect;
            }


            if (_statusEffectCheck != null)
            {
                return _statusEffectCheck.Counters <= counters ? 1 : 0;
            }
            else
            {
                return 0;
            }
        }
   



    }
}
