using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    public class CalculatedValueAsset : ScriptableObject, ICalculatedValueAsset
    {
        private float _calculatedValue;
        
        public void SetCalculatedValue(IHero targetHero)
        {
            _calculatedValue = 0;
        }

        public float GetCalculatedValue()
        {
            return _calculatedValue;
        }


    }
}
