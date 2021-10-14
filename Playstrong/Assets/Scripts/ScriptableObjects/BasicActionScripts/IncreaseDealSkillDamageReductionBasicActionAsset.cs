using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "IncreaseDealSkillDamageReduction", menuName = "SO's/BasicActions/IncreaseDealSkillDamageReduction")]
    
    public class IncreaseDealSkillDamageReductionBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int damageReductionValue;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.DealSkillDamageReduction += damageReductionValue;
            
            Debug.Log("DealSkillDamageReduction: " +targetHero.HeroLogic.OtherAttributes.DealSkillDamageReduction);
            Debug.Log("Hero: " +targetHero.HeroName);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.DealSkillDamageReduction -= damageReductionValue;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
