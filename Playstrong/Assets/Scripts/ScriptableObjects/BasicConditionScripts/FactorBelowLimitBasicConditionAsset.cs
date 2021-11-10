using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    
    /// <summary>
    /// Compares calculated factor values - attack, health, buffs, fighting spirit, etc
    /// with a defined limit.  Returns 1 when the value is greater than the limit 
    /// </summary>
    [CreateAssetMenu(fileName = "FactorBelowLimit", menuName = "SO's/BasicConditions/FactorBelowLimit")]
    public class FactorBelowLimitBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private int limit;
        
        [SerializeField] private ScriptableObject calculatedFactor;
        private ICalculatedFactorValueAsset CalculatedFactor => calculatedFactor as ICalculatedFactorValueAsset;
        
        [SerializeField] private ScriptableObject calculatedLimit;
        private ICalculatedFactorValueAsset CalculatedLimit => calculatedLimit as ICalculatedFactorValueAsset;

        protected override int CheckBasicCondition(IHero targetHero)
        {
            limit += (int)CalculatedLimit.GetCalculatedValue();
            
            return CalculatedFactor.GetCalculatedValue() < limit ? 1 : 0;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            limit += (int)CalculatedLimit.GetCalculatedValue();
            
            return CalculatedFactor.GetCalculatedValue() < limit ? 1 : 0;
        }

    }
}
