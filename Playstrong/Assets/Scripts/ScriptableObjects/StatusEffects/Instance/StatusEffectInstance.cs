using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    public class StatusEffectInstance : ScriptableObject, IStatusEffectInstance
    {
        
        protected IHeroStatusEffect ExistingStatusEffect;
        protected IHeroStatusEffect NewStatusEffect;
        
        public virtual void AddStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {
 
        }
    
        protected IHeroStatusEffect CreateStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {
            var statusEffectPrefab = targetHero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = targetHero.HeroStatusEffects.StatusEffectsPanel.Transform;
            
            var statusEffectObject = Instantiate(statusEffectPrefab, statusEffectPanel);
            statusEffectObject.transform.SetParent(statusEffectPanel);
            
            //Return this
            var heroStatusEffect = statusEffectObject.GetComponent<IHeroStatusEffect>();

            heroStatusEffect.LoadStatusEffectValues.LoadValues(statusEffectAsset, statusEffectCounters);

            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect(targetHero);

            heroStatusEffect.CoroutineTreesAsset = targetHero.CoroutineTreesAsset;
            heroStatusEffect.TargetHero = targetHero;
            heroStatusEffect.CasterHero = casterHero;
            

            //Add to respective StatusEffects List in HeroStatusEffects
            heroStatusEffect.StatusEffectType.AddToStatusEffectsList(targetHero.HeroStatusEffects, heroStatusEffect);
            
            //Status Effect Preview
            var statusEffectPreviewPrefab = targetHero.HeroStatusEffects.StatusEffectPreviewPrefab;
            var statusEffectPreviewPanel = targetHero.HeroPreviewVisual.StatusCanvasPanel.transform;

            var heroStatusEffectPreviewObject = Instantiate(statusEffectPreviewPrefab);
            var heroStatusEffectPreview = heroStatusEffectPreviewObject.GetComponent<IStatusEffectPreview>();
            heroStatusEffectPreview.LoadStatusEffectPreview.LoadVisualValues(statusEffectAsset);
            
            //Delayed change parent due to inactive Parent gameObject
            heroStatusEffectPreviewObject.transform.SetParent(statusEffectPreviewPanel);
           
            
            //TEMP. TODO: Transfer this to LoadValues
            heroStatusEffect.StatusEffectPreview = heroStatusEffectPreviewObject;

            return heroStatusEffect;
            
        }

        protected void CheckExistingStatusEffects(IHero targetHero, IStatusEffectAsset addStatusEffectAsset)
        {

            foreach (var statusEffect in targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs )
            {
                if (addStatusEffectAsset == statusEffect.StatusEffectAsset)
                    ExistingStatusEffect = statusEffect;
            }
            
            foreach (var statusEffect in targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs )
            {
                if (addStatusEffectAsset == statusEffect.StatusEffectAsset)
                {
                    ExistingStatusEffect = statusEffect;
                }
            }
        }
        
        protected void UpdateStatusEffect(IHeroStatusEffect existingStatusEffect,int counters, IHero targetHero, IHero casterHero)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            var existingStatusEffectCounters = existingStatusEffect.Counters;
            var newCounters = Mathf.Max(counters, existingStatusEffectCounters);

            ExistingStatusEffect.SetStatusEffectCounters.SetCounters(newCounters, coroutineTreesAsset);
            ExistingStatusEffect.CasterHero = casterHero;

        }
        
        
    
    }
}
