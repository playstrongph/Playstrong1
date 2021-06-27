using Interfaces;
using Logic;
using UnityEngine;
using Visual;

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
            var statusEffectPrefab = hero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = hero.HeroStatusEffects.StatusEffectsPanel.Transform;
            
            var statusEffectObject = Instantiate(statusEffectPrefab, statusEffectPanel);
            statusEffectObject.transform.SetParent(statusEffectPanel);
            var heroStatusEffect = statusEffectObject.GetComponent<IHeroStatusEffect>();

            heroStatusEffect.LoadStatusEffectValues.LoadValues(statusEffectAsset, statusEffectCounters);

            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect(hero);

            heroStatusEffect.CoroutineTreesAsset = hero.CoroutineTreesAsset;
            heroStatusEffect.Hero = hero;

            //Add to respective StatusEffects List in HeroStatusEffects
            heroStatusEffect.StatusEffectType.AddToStatusEffectsList(hero.HeroStatusEffects, heroStatusEffect);
            
            //Status Effect Preview
            var statusEffectPreviewPrefab = hero.HeroStatusEffects.StatusEffectPreviewPrefab;
            var statusEffectPreviewPanel = hero.HeroPreviewVisual.StatusCanvasPanel.transform;

            var heroStatusEffectPreviewObject = Instantiate(statusEffectPreviewPrefab, statusEffectPreviewPanel);
            heroStatusEffectPreviewObject.transform.SetParent(statusEffectPreviewPanel);
            var heroStatusEffectPreview = heroStatusEffectPreviewObject.GetComponent<IStatusEffectPreview>();

            //heroStatusEffectPreview.LoadStatusEffectPreview.LoadVisualValues(statusEffectAsset);
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
