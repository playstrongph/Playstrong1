using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCriticalChance", menuName = "SO's/BasicActions/IncreaseCriticalChance")]
    
    public class IncreaseCriticalChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int criticalChanceIncrease;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance += criticalChanceIncrease;
            
            //Debug.Log(" IncreaseCrit Chance 1 targetHero: " +targetHero.HeroName +" HeroCritChance: " +targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance += criticalChanceIncrease;
            
            //Debug.Log(" IncreaseCrit Chance 2 targetHero: " +targetHero.HeroName +" HeroCritChance: " +targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance -= criticalChanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance -= criticalChanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
