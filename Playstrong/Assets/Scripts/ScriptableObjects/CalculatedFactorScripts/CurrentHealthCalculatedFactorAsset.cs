using ScriptableObjects.DamageAttributeMultiple;
using UnityEngine;

namespace ScriptableObjects.CalculatedDamageFactorValue
{
    
    [CreateAssetMenu(fileName = "CurrentHealthFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/CurrentHealthFactor")]
    public class CurrentHealthCalculatedFactorAsset : CalculatedFactorValueAsset
    {
        public override float GetCalculatedValue()
        {
            var healthFactor = 0;
            
            //Damage Taken Factor
            if (CalculationHeroBasis != null)
                healthFactor = Mathf.CeilToInt(CalculationHeroBasis.HeroLogic.HeroAttributes.Health * percentFactor / 100f);
            
            Debug.Log("Hero Basis: " +CalculationHeroBasis.HeroName +"  Health: " +healthFactor);
            
            //Debug.Log("Max Health Factor: " +healthFactor);

            return healthFactor;
        }
       
    }
}
