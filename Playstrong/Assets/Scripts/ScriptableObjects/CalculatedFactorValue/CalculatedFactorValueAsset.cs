using Interfaces;
using Logic;
using References;
using ScriptableObjects.CalculatedFactorValue;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    /// <summary>
    /// Base class Asset used by DealDamageBasicAction for calculated damage
    /// Use cases - Proportional Damage - e.g. damage according to your speed, enemy speed, your max HP, enemy max HP, etc.
    /// Use cases - max HP of weakest Hero, Speed of fastest hero, etc.
    /// Inheritors also implement ICalculatedValueAsset as used by DealDamage 
    /// </summary>
    public class CalculatedFactorValueAsset : ScriptableObject, ICalculatedFactorValueAsset
    {
        
       [SerializeField] protected int percentFactor;

       protected IHero CalculationHeroBasis;
       
       public virtual float GetCalculatedValue()
        {
            var calculatedValue = 0;
            return calculatedValue;
        }
        
        public void SetHeroBasis(IHero hero)
        {
            CalculationHeroBasis = hero;
            
           
        }

    }
}
