using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    [CreateAssetMenu(fileName = "BaseAttackFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/BaseAttackFactor")]
    public class BaseAttackCalculatedFactorAsset : CalculatedFactorValueAsset
    {
        public override float GetCalculatedValue()
        {
            var baseAttackFactor = 0;

            if (CalculationHeroBasis != null)
                baseAttackFactor = Mathf.RoundToInt(CalculationHeroBasis.HeroLogic.HeroAttributes.BaseAttack * percentFactor / 100f);

            return baseAttackFactor;
        }
       
    }
}
