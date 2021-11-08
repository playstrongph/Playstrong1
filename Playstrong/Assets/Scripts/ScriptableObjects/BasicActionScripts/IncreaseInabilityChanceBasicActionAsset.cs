using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseInabilityChance", menuName = "SO's/BasicActions/I/IncreaseInabilityChance")]
    
    public class IncreaseInabilityChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int inabilityChance;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.HeroInabilityChance += inabilityChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.HeroInabilityChance -= inabilityChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
