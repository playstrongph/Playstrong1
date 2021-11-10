using System.Runtime.CompilerServices;
using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    /// <summary>
    /// Asset used by DealDamage basic action to deal percent damage according to damage taken by the hero
    /// </summary>
    [CreateAssetMenu(fileName = "FinalDamageTaken", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/FinalDamageTaken")]
    public class DamageTakeDamageFactorAsset : CalculatedFactorValueAsset
    {
        private int _damageFactor;
        public override float GetCalculatedValue()
        {
            var damageFactor = 0;
            
            //Damage Taken Factor
            if (CalculationHeroBasis != null)
            {
                damageFactor = Mathf.CeilToInt(CalculationHeroBasis.HeroLogic.TakeDamageTest.FinalDamage * percentFactor / 100f);

                Debug.Log("FinalDamage: " +CalculationHeroBasis.HeroLogic.TakeDamageTest.FinalDamage +" percentFactor: " +percentFactor );
                Debug.Log("Hero Basis: " +CalculationHeroBasis.HeroName +" Damage Factor: " +damageFactor );
            }
            
            return damageFactor;
        }
       
    }
}
