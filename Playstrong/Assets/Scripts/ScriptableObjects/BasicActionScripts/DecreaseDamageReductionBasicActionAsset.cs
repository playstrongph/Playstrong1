using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseDamageReduction", menuName = "SO's/BasicActions/DecreaseDamageReduction")]
    public class DecreaseDamageReductionBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int damageReductionValue;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.TakeAllDamageReduction -= damageReductionValue;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.TakeAllDamageReduction += damageReductionValue;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
