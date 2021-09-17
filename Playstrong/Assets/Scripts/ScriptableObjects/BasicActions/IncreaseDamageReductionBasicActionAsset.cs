using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "IncreaseDamageReduction", menuName = "SO's/BasicActions/IncreaseDamageReduction")]
    
    public class IncreaseDamageReductionBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int damageReductionValue;

       
        public override IEnumerator TargetAction(IHero targetHero, float value)
        {
            damageReductionValue = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.DamageReduction += damageReductionValue;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
