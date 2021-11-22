using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.CalculatedFactorValue;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    /// <summary>
    /// Base class Asset used by DealDamageBasicAction for calculated damage
    /// Use cases - Proportional Damage - e.g. damage according to your speed, enemy speed, your max HP, enemy max HP, etc.
    /// Use cases - max HP of weakest Hero, Speed of fastest hero, etc.
    /// Inheritors also implement ICalculatedValueAsset as used by DealDamage 
    /// </summary>
    public class CalculatedFactorValueAsset : ScriptableObject, ICalculatedFactorValueAsset
    {
        
       [SerializeField] protected int percentFactor;

       protected IHero CalculationHeroBasis;
       
       /// <summary>
       /// Used in conjunction with SetCalculatedFactor basic action
       /// when GetCalculatedValue needs to be taken at a specific point in time
       /// </summary>
       /// <returns></returns>
       public virtual float GetCalculatedValue()
        {
            var calculatedValue = 0;
            return calculatedValue;
        }
        
        public void SetHeroBasis(IHero hero)
        {
            CalculationHeroBasis = hero;
        }
        
        
        protected List<int> ShuffleList(List<int> values)
        {
            var randomList = values;
            
            //Randomize the List
            for (int i = 0; i < randomList.Count; i++) 
            {
                var temp = randomList[i];
                int randomIndex = Random.Range(i, randomList.Count);
                randomList[i] = randomList[randomIndex];
                randomList[randomIndex] = temp;
            }

            return randomList;
        }

    }
}
