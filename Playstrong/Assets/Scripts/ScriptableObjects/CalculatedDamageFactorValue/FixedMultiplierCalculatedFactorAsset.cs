using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    /// <summary>
    /// Asset used by DealDamage basic action to deal percent damage according to damage taken by the hero
    /// </summary>
    [CreateAssetMenu(fileName = "FixedMultiplierFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/FixedMultiplierFactor")]
    public class FixedMultiplierCalculatedFactorAsset : CalculatedFactorValueAsset
    {
       
        
        public override float GetCalculatedValue()
        {
            var multiplier = percentFactor / 100f; 
           return multiplier;
        }
       
    }
}
