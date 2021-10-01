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

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.TakeAllDamageReduction += damageReductionValue;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.TakeAllDamageReduction -= damageReductionValue;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
