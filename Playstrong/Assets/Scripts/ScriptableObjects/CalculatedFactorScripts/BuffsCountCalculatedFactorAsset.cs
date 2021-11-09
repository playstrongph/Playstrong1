using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "BuffsCountFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/BuffsCountFactor")]
    public class BuffsCountCalculatedFactorAsset : CalculatedFactorValueAsset
    {
        
        public override float GetCalculatedValue()
        {
            var buffsCount = 0;
            
            //Damage Taken Factor
            if (CalculationHeroBasis != null)
                buffsCount = CalculationHeroBasis.HeroStatusEffects.HeroBuffEffects.HeroBuffs.Count;

            return buffsCount;
        }
       
    }
}
