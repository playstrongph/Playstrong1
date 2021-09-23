using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    /// <summary>
    /// Base class used in DealDamage Basic action to determine calculated damage
    /// </summary>
    public class CalculatedValueAsset : ScriptableObject, ICalculatedValueAsset
    {
        private float _calculatedValue;
        
        public void SetCalculatedValue(IHero hero)
        {
            _calculatedValue = 0;
        }
        
        public void SetCalculatedValue(IHero thisHero, IHero targetHero)
        {
            _calculatedValue = 0;
        }

        public float GetCalculatedValue()
        {
            return _calculatedValue;
        }


    }
}
