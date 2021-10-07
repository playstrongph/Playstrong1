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
            
            //CREATE STATUS EFFECT GAME OBJECT
            var statusEffectPrefab = targetHero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = targetHero.HeroStatusEffects.StatusEffectsPanel.Transform;
            var statusEffectObject = Instantiate(statusEffectPrefab, statusEffectPanel);
            var heroStatusEffect = statusEffectObject.GetComponent<IHeroStatusEffect>();
            statusEffectObject.transform.SetParent(statusEffectPanel);
            
            //This should come before LoadStatusEffectValues due to cloning of SO
            statusEffectAsset.CasterHero = casterHero;             //Using this is wrong!
            

            //Loads Values of HeroStatusEffectAsset to HeroStatusEffect Component
            heroStatusEffect.StatusEffectCasterHero = casterHero;
            heroStatusEffect.StatusEffectTargetHero = targetHero;
            heroStatusEffect.CoroutineTreesAsset = targetHero.CoroutineTreesAsset;
            heroStatusEffect.LoadStatusEffectValues.LoadValues(targetHero,statusEffectAsset, statusEffectCounters,casterHero);
           
            //Add to respective StatusEffects List in HeroStatusEffects
            heroStatusEffect.StatusEffectType.AddToStatusEffectsList(targetHero.HeroStatusEffects, heroStatusEffect);

            
            //This is where statusEffect effects Gets applied
            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect(targetHero);
            heroStatusEffect.StatusEffectAsset.CasterHero = casterHero;

            //STATUS EFFECT PREVIEW
            CreateStatusEffectPreview(targetHero, statusEffectAsset, heroStatusEffect);
            
            return heroStatusEffect;
        }
        
        protected IHeroStatusEffect CreateStackingStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {

            var statusEffectPrefab = targetHero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = targetHero.HeroStatusEffects.StatusEffectsPanel.Transform;
            
            var statusEffectObject = Instantiate(statusEffectPrefab, statusEffectPanel);
            statusEffectObject.transform.SetParent(statusEffectPanel);
            
            //Return this
            var heroStatusEffect = statusEffectObject.GetComponent<IHeroStatusEffect>();
            
            //This should come before LoadStatusEffectValues due to cloning of SO
            statusEffectAsset.CasterHero = casterHero;
            heroStatusEffect.StatusEffectCasterHero = casterHero;

            heroStatusEffect.LoadStatusEffectValues.LoadValues(targetHero,statusEffectAsset, statusEffectCounters,casterHero);

            
            //This is where statusEffect Gets applied
            //heroStatusEffect.StatusEffectAsset.ApplyStatusEffect(targetHero);
            
            //stacking effect if counters > 1
            for (int i = 0; i < statusEffectCounters; i++)
            {
                heroStatusEffect.StatusEffectAsset.ApplyStackingEffect(targetHero);
            }


            heroStatusEffect.CoroutineTreesAsset = targetHero.CoroutineTreesAsset;
            heroStatusEffect.StatusEffectTargetHero = targetHero;

            statusEffectAsset.CasterHero = casterHero;
            heroStatusEffect.StatusEffectCasterHero = casterHero;
            

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
            
            foreach (var statusEffect in targetHero.HeroStatusEffects.HeroSkillBuffEffects.HeroSkillBuffs )
            {
                if (addStatusEffectAsset.Name == statusEffect.StatusEffectAsset.Name)
                    return statusEffect;
            }
            
            foreach (var statusEffect in targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs )
            {
                if (addStatusEffectAsset.Name == statusEffect.StatusEffectAsset.Name)
                    return statusEffect;
            }
            
            foreach (var statusEffect in targetHero.HeroStatusEffects.HeroSkillDebuffEffects.HeroSkillDebuffs )
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
            
            existingStatusEffect.StatusEffectCasterHero = casterHero;
            statusEffectAsset.CasterHero = casterHero;

        }
        protected void UpdateStackingStatusEffect(IHeroStatusEffect existingStatusEffect, IStatusEffectAsset statusEffectAsset, int counters, IHero targetHero, IHero casterHero)
        {
            var coroutineTreesAsset = targetHero.CoroutineTreesAsset;
            var existingStatusEffectCounters = existingStatusEffect.Counters;
            var maxSkillCounters = statusEffectAsset.MaxSkillCounters;
            
            //allowed, additional counters for stacking status effects
            //floor limit of zero (just to be safe, but check not required)
            var newCountersLimit = maxSkillCounters - existingStatusEffectCounters;
            newCountersLimit = Mathf.Max(newCountersLimit, 0);
            
            //Check if new additional counters are within the limit
            //get the smaller value in case counters exceed the limit.
            var additionalCounters = Mathf.Min(newCountersLimit, counters);
            
            //New counters shouldn't exceed the maxCounters limit due to additional counters calculation
            var newCounters = existingStatusEffectCounters + additionalCounters;
            //newCounters = Mathf.Min(newCounters, maxSkillCounters);  //not required

            //Set the new skill status effect counters
            existingStatusEffect.StatusEffectInstance.SetCounters(existingStatusEffect,targetHero,newCounters);
            
            //Apply stacking effect times the number of additionalCounters
            for(int i =0; i < additionalCounters; i++)
            {
                statusEffectAsset.ApplyStackingEffect(targetHero);
            }
            
            existingStatusEffect.StatusEffectCasterHero = casterHero;
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

        private void CreateStatusEffectPreview(IHero targetHero, IStatusEffectAsset statusEffectAsset, IHeroStatusEffect heroStatusEffect)
        {
            var statusEffectPreviewPrefab = targetHero.HeroStatusEffects.StatusEffectPreviewPrefab;
            var statusEffectPreviewPanel = targetHero.HeroPreviewVisual.StatusCanvasPanel.transform;
            var heroStatusEffectPreviewObject = Instantiate(statusEffectPreviewPrefab);
            var heroStatusEffectPreview = heroStatusEffectPreviewObject.GetComponent<IStatusEffectPreview>();
            heroStatusEffectPreview.LoadStatusEffectPreview.LoadVisualValues(statusEffectAsset);
            //Delayed change parent due to inactive Parent gameObject
            heroStatusEffectPreviewObject.transform.SetParent(statusEffectPreviewPanel);
            heroStatusEffect.StatusEffectPreview = heroStatusEffectPreviewObject;
        }






    }
}
