using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "AttackFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/AttackFactor")]
    public class AttackDamageFactorAsset : CalculatedFactorValueAsset
    {

        public override float GetCalculatedValue()
        {
            var damageFactor = 0;
            
            //Damage Taken Factor
            if (OtherHeroBasis != null)
                damageFactor = Mathf.CeilToInt(OtherHeroBasis.HeroLogic.HeroAttributes.Attack * percentFactor / 100f);

            return damageFactor;
        }
       
    }
}
