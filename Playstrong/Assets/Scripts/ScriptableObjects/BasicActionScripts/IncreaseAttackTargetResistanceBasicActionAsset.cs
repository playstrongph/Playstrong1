using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAttackTargetResistance", menuName = "SO's/BasicActions/I/IncreaseAttackTargetResistance")]
    
    public class IncreaseAttackTargetResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int attackTargetResistance;

        public override IEnumerator TargetAction(IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.AttackTargetResistance += attackTargetResistance;
            
            logicTree.EndSequence();
            yield return null;
        } 
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.AttackTargetResistance -= attackTargetResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
