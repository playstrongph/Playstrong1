using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "SingleInstance", menuName = "SO's/Status Effects/Instance/Single Instance")]
    public class SingleInstance : ScriptableObject, IStatusEffectInstance
    {
        private IHeroStatusEffect _existingStatusEffect;

        /// <summary>
        /// Checks if there is an existing status effect on the hero
        /// Create a new one if there is none
        /// Update the status effect counters if it exists 
        /// </summary>
        
        public void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            CheckExistingStatusEffects(hero, statusEffectAsset);
            
            if (_existingStatusEffect != null)
                UpdateStatusEffect(_existingStatusEffect,statusEffectCounters, hero);
            else
                CreateStatusEffect(hero, statusEffectAsset, statusEffectCounters);
        }
        
        
        private void CheckExistingStatusEffects(IHero hero, IStatusEffectAsset addStatusEffectAsset)
        {
            //var statusEffectExists = false;
            
            foreach (var statusEffect in hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs )
            {
                if (addStatusEffectAsset == statusEffect.StatusEffectAsset)
                {
                    //statusEffectExists = true;
                    _existingStatusEffect = statusEffect;
                }
            }
            
            foreach (var statusEffect in hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs )
            {
                if (addStatusEffectAsset == statusEffect.StatusEffectAsset)
                {
                    //statusEffectExists = true;
                    _existingStatusEffect = statusEffect;
                }
            }

            //return statusEffectExists;
        }

        private void CreateStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            var buffEffectPrefab = hero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = hero.HeroStatusEffects.StatusEffectsPanel.Transform;
            
            var buffEffectObject = Instantiate(buffEffectPrefab, statusEffectPanel);
            buffEffectObject.transform.SetParent(statusEffectPanel);
            var heroStatusEffect = buffEffectObject.GetComponent<IHeroStatusEffect>();

            heroStatusEffect.LoadStatusEffectValues.LoadValues(statusEffectAsset, statusEffectCounters);
            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect();
            heroStatusEffect.CoroutineTreesAsset = hero.CoroutineTreesAsset;

            //Add to respective StatusEffects List in HeroStatusEffects
            heroStatusEffect.StatusEffectType.AddToStatusEffectsList(hero.HeroStatusEffects, heroStatusEffect);
        }

        private void UpdateStatusEffect(IHeroStatusEffect existingStatusEffect,int counters, IHero hero)
        {
            var coroutineTreesAsset = hero.CoroutineTreesAsset;
            var existingStatusEffectCounters = existingStatusEffect.Counters;
            var newCounters = Mathf.Max(counters, existingStatusEffectCounters);

            _existingStatusEffect.SetStatusEffectCounters.SetCounters(newCounters, coroutineTreesAsset);
            
            
        }
        
        
    }
}
