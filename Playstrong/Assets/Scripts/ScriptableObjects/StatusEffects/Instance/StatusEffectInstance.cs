using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    public class StatusEffectInstance : ScriptableObject, IStatusEffectInstance
    {
        
        protected IHeroStatusEffect ExistingStatusEffect;
        public virtual void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
 
        }
    
        protected void CreateStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            var buffEffectPrefab = hero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = hero.HeroStatusEffects.StatusEffectsPanel.Transform;
            
            var buffEffectObject = Instantiate(buffEffectPrefab, statusEffectPanel);
            buffEffectObject.transform.SetParent(statusEffectPanel);
            var heroStatusEffect = buffEffectObject.GetComponent<IHeroStatusEffect>();

            heroStatusEffect.LoadStatusEffectValues.LoadValues(statusEffectAsset, statusEffectCounters);
            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect();
            
            heroStatusEffect.CoroutineTreesAsset = hero.CoroutineTreesAsset;
            heroStatusEffect.Hero = hero;

            //Add to respective StatusEffects List in HeroStatusEffects
            heroStatusEffect.StatusEffectType.AddToStatusEffectsList(hero.HeroStatusEffects, heroStatusEffect);
        }
        
        protected void CheckExistingStatusEffects(IHero hero, IStatusEffectAsset addStatusEffectAsset)
        {

            foreach (var statusEffect in hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs )
            {
                if (addStatusEffectAsset == statusEffect.StatusEffectAsset)
                    ExistingStatusEffect = statusEffect;
            }
            
            foreach (var statusEffect in hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs )
            {
                if (addStatusEffectAsset == statusEffect.StatusEffectAsset)
                {
                    ExistingStatusEffect = statusEffect;
                }
            }
        }
        
        protected void UpdateStatusEffect(IHeroStatusEffect existingStatusEffect,int counters, IHero hero)
        {
            var coroutineTreesAsset = hero.CoroutineTreesAsset;
            var existingStatusEffectCounters = existingStatusEffect.Counters;
            var newCounters = Mathf.Max(counters, existingStatusEffectCounters);

            ExistingStatusEffect.SetStatusEffectCounters.SetCounters(newCounters, coroutineTreesAsset);

        }
        
        
    
    }
}
