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

        public void AddStatusEffect(IHero hero)
        {
            if(CheckStatusEffectExistence(hero))
                UpdateStatusEffect();
            else
                CreateStatusEffect();
            
        }
        
        
        public bool CheckStatusEffectExistence(IHero hero)
        {
            IHeroStatusEffect statusEffect;
            foreach (var buff in hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs )
            {
              
                    
            }
            
            var statusEffectExists = false;
            return statusEffectExists;
        }

        public void CreateStatusEffect()
        {
            
        }

        public void UpdateStatusEffect()
        {
            
        }
        
        
    }
}
