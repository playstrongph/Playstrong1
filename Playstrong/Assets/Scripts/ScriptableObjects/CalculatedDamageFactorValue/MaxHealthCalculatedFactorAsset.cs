using ScriptableObjects.DamageAttributeMultiple;
using UnityEngine;

namespace ScriptableObjects.CalculatedDamageFactorValue
{
    
    [CreateAssetMenu(fileName = "MaxHealthFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/MaxHealthFactor")]
    public class MaxHealthCalculatedFactorAsset : CalculatedFactorValueAsset
    {
        public override float GetCalculatedValue()
        {
            var healthFactor = 0;
            
            //Damage Taken Factor
            if (OtherHeroBasis != null)
                healthFactor = Mathf.CeilToInt(OtherHeroBasis.HeroLogic.HeroAttributes.BaseHealth * percentFactor / 100f);
            
            Debug.Log("Max Health Factor: " +healthFactor);

            return healthFactor;
        }
       
    }
}
