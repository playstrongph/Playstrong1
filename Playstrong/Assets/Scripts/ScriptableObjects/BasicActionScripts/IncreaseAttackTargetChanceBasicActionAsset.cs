using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAttackTargetChance", menuName = "SO's/BasicActions/I/IncreaseAttackTargetChance")]
    
    public class IncreaseAttackTargetChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int attackTargetChance;

        public override IEnumerator TargetAction(IHero targetHero) 
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.AttackTargetChance += attackTargetChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero) 
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.AttackTargetChance -= attackTargetChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
