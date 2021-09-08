using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    public class StatusEffectInstance : ScriptableObject, IStatusEffectInstance
    {
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
            
            //This should come before LoadStatusEffectValues due to cloning of SO
            statusEffectAsset.CasterHero = casterHero;
            heroStatusEffect.CasterHero = casterHero;

            heroStatusEffect.LoadStatusEffectValues.LoadValues(statusEffectAsset, statusEffectCounters);

            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect(targetHero);

            heroStatusEffect.CoroutineTreesAsset = targetHero.CoroutineTreesAsset;
            heroStatusEffect.TargetHero = targetHero;

            statusEffectAsset.CasterHero = casterHero;
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

        protected IHeroStatusEffect CheckExistingStatusEffects(IHero targetHero, IStatusEffectAsset addStatusEffectAsset)
        {
            foreach (var statusEffect in targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs )
            {
                if (addStatusEffectAsset.Name == statusEffect.StatusEffectAsset.Name)
                    return statusEffect;
            }
            
            foreach (var statusEffect in targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs )
            {
                if (addStatusEffectAsset.Name == statusEffect.StatusEffectAsset.Name)
                    return statusEffect;
            }

            return null;
        }
        
        protected void UpdateStatusEffect(IHeroStatusEffect existingStatusEffect, IStatusEffectAsset statusEffectAsset, int counters, IHero targetHero, IHero casterHero)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            var existingStatusEffectCounters = existingStatusEffect.Counters;
            var newCounters = Mathf.Max(counters, existingStatusEffectCounters);

            //Original
            //ExistingStatusEffect.SetStatusEffectCounters.SetCounters(newCounters, coroutineTreesAsset);
            
            //TEST
            existingStatusEffect.StatusEffectInstance.SetCounters(existingStatusEffect,targetHero,newCounters);
            
            existingStatusEffect.CasterHero = casterHero;
            statusEffectAsset.CasterHero = casterHero;

        }

        public virtual void IncreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            existingStatusEffect.IncreaseStatusEffectCounters.IncreaseCounters(counters,coroutineTreesAsset);
        }
        
        public virtual void DecreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            existingStatusEffect.DecreaseStatusEffectCounters.DecreaseCounters(counters,coroutineTreesAsset);
        }
        
        public virtual void SetCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            existingStatusEffect.SetStatusEffectCounters.SetCounters(counters,coroutineTreesAsset);
        }
        
        /// <summary>
        /// Methods to be used by dispel actions - Remove Buff or Remove Debuff
        /// </summary>
        public virtual void DispelStatusEffect(IHeroStatusEffect existingStatusEffect, IHero targetHero)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            existingStatusEffect.RemoveStatusEffect.RemoveEffect(targetHero);
        }
        
        
        
        
        



    }
}
