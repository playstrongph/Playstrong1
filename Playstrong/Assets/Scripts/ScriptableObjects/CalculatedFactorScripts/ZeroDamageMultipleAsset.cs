using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    /// <summary>
    /// Asset used by DealDamage basic action to deal percent damage according to damage taken by the hero
    /// </summary>
    [CreateAssetMenu(fileName = "ZeroFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/ZeroFactor")]
    public class ZeroDamageMultipleAsset : CalculatedFactorValueAsset
    {
        private int _damageMultiple;
        
        public override float GetCalculatedValue()
        {
            var damageFactor = 0;
            return damageFactor;
        }
       
    }
}
