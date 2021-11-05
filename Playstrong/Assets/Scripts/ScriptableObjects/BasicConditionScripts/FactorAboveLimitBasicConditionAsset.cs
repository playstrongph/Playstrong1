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
    [CreateAssetMenu(fileName = "FactorAboveLimit", menuName = "SO's/BasicConditions/FactorAboveLimit")]
    
    public class FactorAboveLimitBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private int limit;
        
        [SerializeField] private ScriptableObject calculatedFactor;
        
        private ICalculatedFactorValueAsset CalculatedFactor => calculatedFactor as ICalculatedFactorValueAsset;

        protected override int CheckBasicCondition(IHero targetHero)
        {
            return CalculatedFactor.GetCalculatedValue(targetHero) > limit ? 1 : 0;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            return CalculatedFactor.GetCalculatedValue(thisHero,targetHero) > limit ? 1 : 0;
        }
   



    }
}
