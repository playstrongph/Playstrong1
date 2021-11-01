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
            
            //Debug.Log("DecreaseCritChance 1 targetHero: " +targetHero.HeroName +" HeroCritChance: " +targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance -= decreaseCriticalChance;
            
            //Debug.Log("DecreaseCritChance 2 targetHero: " +targetHero.HeroName +" HeroCritChance: " +targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance);
            
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
        
        public override IEnumerator UndoTargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance += decreaseCriticalChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
