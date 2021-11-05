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
       
       /// <summary>
       /// Used in conjunction with SetCalculatedFactor basic action
       /// when GetCalculatedValue needs to be taken at a specific point in time
       /// </summary>
       /// <returns></returns>
       public virtual float GetCalculatedValue()
        {
            var calculatedValue = 0;
            return calculatedValue;
        }
        
        public void SetHeroBasis(IHero hero)
        {
            CalculationHeroBasis = hero;
        }
        
        
        /*/// <summary>
        /// Can be used when calculated value does not need to be constant
        /// or not used across multiple conditions/actions
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public virtual float GetCalculatedValue(IHero targetHero)
        {
            var calculatedValue = 0;
            return calculatedValue;
        }
        
        /// <summary>
        /// Can be used when calculated value does not need to be constant
        /// or not used across multiple conditions/actions
        /// </summary>
        /// <param name="thisHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public virtual float GetCalculatedValue(IHero thisHero, IHero targetHero)
        {
            var calculatedValue = 0;
            return calculatedValue;
        }*/

    }
}
