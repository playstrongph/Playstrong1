using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreasePenetrateArmorChance", menuName = "SO's/BasicActions/I/IncreasePenetrateArmorChance")]
    
    public class IncreasePenetrateArmorChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int penetrateArmorChance ;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.PenetrateArmorChance += penetrateArmorChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.PenetrateArmorChance += penetrateArmorChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.PenetrateArmorChance -= penetrateArmorChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.PenetrateArmorChance -= penetrateArmorChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
