using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseSkillDamageReduction", menuName = "SO's/BasicActions/IncreaseSkillDamageReduction")]
    
    public class IncreaseSkillDamageReductionBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int damageReduction;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
          
            targetHero.HeroLogic.OtherAttributes.SkillDamageReduction += damageReduction;
            Debug.Log("TargetAction IncreaseSkillDamageReduction: " +targetHero.HeroLogic.OtherAttributes.SkillDamageReduction );

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.SkillDamageReduction -= damageReduction;
            Debug.Log("Undo IncreaseSkillDamageReduction: " +targetHero.HeroLogic.OtherAttributes.SkillDamageReduction );

            logicTree.EndSequence();
            yield return null;
        }
        
        /*public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.SkillDamageReduction += damageReduction;

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.SkillDamageReduction -= damageReduction;

            logicTree.EndSequence();
            yield return null;
        }*/


      

      










    }
}
