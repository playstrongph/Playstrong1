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
            if (OtherHeroBasis != null)
            {
                damageFactor = Mathf.CeilToInt(OtherHeroBasis.HeroLogic.TakeDamageTest.FinalDamage * percentFactor / 100f);  
                
                Debug.Log("FinalDamage: " +OtherHeroBasis.HeroLogic.TakeDamageTest.FinalDamage +" percentFactor: " +percentFactor );
                
                Debug.Log("Hero Basis: " +OtherHeroBasis.HeroName +" Damage Factor: " +damageFactor );
            }
            
            return damageFactor;
        }
       
    }
}
