using Interfaces;
using Logic;
using References;
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
        
        /*[SerializeField] private ScriptableObject actionTargets;
        protected IActionTargets ActionTargets => actionTargets as IActionTargets;
        */

        [SerializeField] protected int percentFactor = 100;

        private IHero _heroBasis;
        
        public virtual int DamageFactorBasis(IHero hero)
        {
            var damageMultiple = 0;
            return damageMultiple;
        }
        
        public virtual int DamageFactorBasis(IHero thisHero, IHero targetHero)
        {
            var damageMultiple = 0;
            return damageMultiple;
        }
        
        public virtual void SetCalculatedValue(IHero thisHero, IHero targetHero)
        {

        }
        
        public virtual void SetCalculatedValue(IHero hero)
        {
           
        }
        
        public virtual float GetCalculatedValue()
        {
            var calculatedValue = 0;
            return calculatedValue;
        }
        
        public virtual float GetCalculatedValue(IHero hero)
        {
            var calculatedValue = 0;
            return calculatedValue;
        }
        
        public virtual float GetCalculatedValue(IHero thisHero, IHero targetHero)
        {
            var calculatedValue = 0;
            return calculatedValue;
        }

        
        //TEST
        protected IHero SetHeroBasis(IHero hero)
        {
            _heroBasis = hero;
            return _heroBasis;
        }
        
        protected IHero SetTargetHeroBasis(IHero thisHero, IHero targetHero)
        {
            _heroBasis = targetHero;
            return _heroBasis;
        }
        
        protected IHero SetThisHeroBasis(IHero thisHero, IHero targetHero)
        {
            _heroBasis = thisHero;
            return _heroBasis;
        }

       

    }
}
