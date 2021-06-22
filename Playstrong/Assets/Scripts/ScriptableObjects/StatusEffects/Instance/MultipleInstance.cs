using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "MultipleInstance", menuName = "SO's/Status Effects/Instance/Multiple Instance")]
    public class MultipleInstance : ScriptableObject, IStatusEffectInstance
    {
        private IHeroStatusEffect _existingStatusEffect;

        /// <summary> 
        /// Always Create a new status effect  
        /// </summary>
        public void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            CreateStatusEffect(hero, statusEffectAsset, statusEffectCounters);
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
