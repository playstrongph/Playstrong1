using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "RandomNumber", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/RandomNumber")]
    public class RandomNumberFactorAsset : CalculatedFactorValueAsset
    {
        [SerializeField]
        private List<int> randomValues = new List<int>();

        private List<int> RandomValues => randomValues;

        public override float GetCalculatedValue()
        {
            return ShuffleList(RandomValues)[0];
        }
       
    }
}
