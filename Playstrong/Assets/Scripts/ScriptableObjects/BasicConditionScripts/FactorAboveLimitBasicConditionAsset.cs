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
    [CreateAssetMenu(fileName = "FactorAboveLimit", menuName = "SO's/BasicConditions/FactorAboveLimit")]
    public class FactorAboveLimitBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private int limit;
        
        [SerializeField] private ScriptableObject calculatedFactor;
        
        private ICalculatedFactorValueAsset CalculatedFactor => calculatedFactor as ICalculatedFactorValueAsset;
        
        [SerializeField] private ScriptableObject calculatedLimit;
        private ICalculatedFactorValueAsset CalculatedLimit => calculatedLimit as ICalculatedFactorValueAsset;

        protected override int CheckBasicCondition(IHero targetHero)
        {
            var totalLimit = limit + (int)CalculatedLimit.GetCalculatedValue();
            
            return CalculatedFactor.GetCalculatedValue() > totalLimit ? 1 : 0;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var totalLimit = limit + (int)CalculatedLimit.GetCalculatedValue();
            
            return CalculatedFactor.GetCalculatedValue() > totalLimit ? 1 : 0;
        }

    }
}
