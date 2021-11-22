using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "RandomAttackFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/RandomAttackFactor")]
    public class RandomAttackCalculatedFactorAsset : CalculatedFactorValueAsset
    {
        [SerializeField]
        private List<int> attackFactorValues = new List<int>();

        private List<int> AttackFactorValues => attackFactorValues;

        public override float GetCalculatedValue()
        {
            var attackFactor = 0;

            var randomAttackFactorValues = ShuffleList(AttackFactorValues);

            var randomPercentFactor = randomAttackFactorValues[0];
            
            //Damage Taken Factor
            if (CalculationHeroBasis != null)
                attackFactor = Mathf.RoundToInt(CalculationHeroBasis.HeroLogic.HeroAttributes.Attack * randomPercentFactor / 100f);
            
            

            return attackFactor;
        }
       
    }
}
