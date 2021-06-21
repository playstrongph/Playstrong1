using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "SingleInstance", menuName = "SO's/Status Effects/Instance/Single Instance")]
    public class SingleInstance : ScriptableObject, IStatusEffectInstance
    {
        private IHeroStatusEffect _existingStatusEffect;
        
        public void AddStatusEffect(IHero hero,  IHeroStatusEffect addStatusEffect, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            if(CheckExistingStatusEffects(hero, addStatusEffect))
                UpdateStatusEffect(addStatusEffect);
            else
                CreateStatusEffect(hero, statusEffectAsset, statusEffectCounters);
            
        }
        
        
        private bool CheckExistingStatusEffects(IHero hero, IHeroStatusEffect addStatusEffect)
        {
            var statusEffectExists = false;
            foreach (var statusEffect in hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs )
            {
                if (addStatusEffect.StatusEffectType == statusEffect.StatusEffectType)
                {
                    statusEffectExists = true;
                    _existingStatusEffect = statusEffect;
                }
            }
            
            foreach (var statusEffect in hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs )
            {
                if (addStatusEffect.StatusEffectType == statusEffect.StatusEffectType)
                {
                    statusEffectExists = true;
                    _existingStatusEffect = statusEffect;
                }
            }

            return statusEffectExists;
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

            //Add to respective StatusEffects List in HeroStatusEffects
            heroStatusEffect.StatusEffectType.AddToStatusEffectsList(hero.HeroStatusEffects, heroStatusEffect);
        }

        private void UpdateStatusEffect(IHeroStatusEffect addStatusEffect)
        {
            var addStatusEffectCounters = addStatusEffect.Counters;
            var existingStatusEffectCounters = _existingStatusEffect.Counters;
            var newCounters = Mathf.Max(addStatusEffectCounters, existingStatusEffectCounters);

            _existingStatusEffect.Counters = newCounters;
        }
        
        
    }
}
