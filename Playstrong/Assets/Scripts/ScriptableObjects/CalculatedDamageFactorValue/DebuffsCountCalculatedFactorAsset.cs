using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "DebuffsCountFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/DebuffsCountFactor")]
    public class DebuffsCountCalculatedFactorAsset : CalculatedFactorValueAsset
    {
        
        public override float GetCalculatedValue()
        {
            var debuffsCount = 0;

            if (CalculationHeroBasis != null)
                debuffsCount = CalculationHeroBasis.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs.Count;

            return debuffsCount;
        }
       
    }
}
