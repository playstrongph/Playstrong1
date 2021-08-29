using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "WithHeroInability", menuName = "SO's/Scriptable Enums/InabilityStatus/WithHeroInability")]
    public class WithHeroInabilityAsset : HeroInabilityAsset
    {

        public override IEnumerator StatusAction(ITurnController turnController)
        {
            
            Debug.Log("With Hero Inability");
            
            var logicTree = turnController.GlobalTrees.MainLogicTree;
            
            //TEST
            //logicTree.AddCurrent(turnController.SetCurrentHeroInactive());
            
            //logicTree.AddCurrent(turnController.StartNextHeroTurn());
            turnController.EndCombatTurn();
            
            logicTree.EndSequence();
            yield return null;
        }
      

    }
}
