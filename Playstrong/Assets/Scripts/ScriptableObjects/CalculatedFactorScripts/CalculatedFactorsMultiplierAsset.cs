using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.CalculatedFactorValue;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    /// <summary>
    /// Multiplies all the calculated factors added in the list and returns the
    /// product.  Example usage is AttackFactor and DebuffCount
    /// </summary>
    
    [CreateAssetMenu(fileName = "CalculatedFactorsMultiplier", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/CalculatedFactorsMultiplier")]
    public class CalculatedFactorsMultiplierAsset : CalculatedFactorValueAsset
    {
        [SerializeField] private List<ScriptableObject> calculatedFactors;

        private List<ICalculatedFactorValueAsset> CalculatedFactors
        {
            get
            {
                var calcFactors = new List<ICalculatedFactorValueAsset>();
                foreach (var factorObject in calculatedFactors)
                {
                    var factor = factorObject as ICalculatedFactorValueAsset;
                    calcFactors.Add(factor);
                }

                return calcFactors;
            }
        }

        public override float GetCalculatedValue()
        {
            var defaultFactor = 1f;
            
            foreach (var calculatedFactor in CalculatedFactors)
            {
                defaultFactor *= calculatedFactor.GetCalculatedValue();
            }

            return defaultFactor;
        }
       
    }
}
