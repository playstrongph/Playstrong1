using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "FixedInstance", menuName = "SO's/Status Effects/Instance/Fixed Instance")]
    public class FixedInstance : ScriptableObject, IStatusEffectInstance
    {
        private IHeroStatusEffect _existingStatusEffect;

        private int _fixedValue = 1;
        
        /// <summary>
        /// Checks if there is an existing status effect on the hero
        /// Create a new one if there is none
        /// Update the status effect counter to a fixed value of one if it exists
        /// </summary>
        public void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            CheckExistingStatusEffects(hero, statusEffectAsset);
            
            if (_existingStatusEffect != null)
                UpdateStatusEffect(_existingStatusEffect,_fixedValue, hero);
            else
                CreateStatusEffect(hero, statusEffectAsset, _fixedValue);
        }
        
        
        private void CheckExistingStatusEffects(IHero hero, IStatusEffectAsset statusEffectAsset)
        {

            foreach (var statusEffect in hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs )
            {
                if (statusEffectAsset == statusEffect.StatusEffectAsset)
                    _existingStatusEffect = statusEffect;
            }
            
            foreach (var statusEffect in hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs )
            {
                if (statusEffectAsset == statusEffect.StatusEffectAsset)
                    _existingStatusEffect = statusEffect;
                
            }
        }

        private void CreateStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            var buffEffectPrefab = hero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = hero.HeroStatusEffects.StatusEffectsPanel.Transform;
            
            var buffEffectObject = Instantiate(buffEffectPrefab, statusEffectPanel);
            buffEffectObject.transform.SetParent(statusEffectPanel);
            var heroStatusEffect = buffEffectObject.GetComponent<IHeroStatusEffect>();
            heroStatusEffect.LoadStatusEffectValues.LoadValues(statusEffectAsset, _fixedValue);
            heroStatusEffect.CoroutineTreesAsset = hero.CoroutineTreesAsset;
            
            //Add to respective StatusEffects List in HeroStatusEffects
            heroStatusEffect.StatusEffectType.AddToStatusEffectsList(hero.HeroStatusEffects, heroStatusEffect);
            
            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect();
            

           
        }

        private void UpdateStatusEffect(IHeroStatusEffect existingStatusEffect,int counters, IHero hero)
        {
            var coroutineTreesAsset = hero.CoroutineTreesAsset;

            _existingStatusEffect.SetStatusEffectCounters.SetCounters(_fixedValue, coroutineTreesAsset);

        }
        
        
    }
}
