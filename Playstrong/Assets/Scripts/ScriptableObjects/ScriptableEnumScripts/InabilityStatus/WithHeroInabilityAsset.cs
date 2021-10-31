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
            var logicTree = turnController.GlobalTrees.MainLogicTree;

            logicTree.AddCurrent(turnController.SetCurrentHeroInactive());
            
            //TEST: UpdateActiveHeroes
            //logicTree.AddCurrent(turnController.UpdateActiveHeroes());
            
            logicTree.AddCurrent(turnController.StartNextHeroTurn());

            logicTree.EndSequence();
            yield return null;
        }
      

    }
}
