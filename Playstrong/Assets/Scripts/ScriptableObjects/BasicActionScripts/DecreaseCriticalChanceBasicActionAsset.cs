using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseCriticalChance", menuName = "SO's/BasicActions/DecreaseCriticalChance")]
    
    public class DecreaseCriticalChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int decreaseCriticalChance;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance -= decreaseCriticalChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance += decreaseCriticalChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
