using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
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
