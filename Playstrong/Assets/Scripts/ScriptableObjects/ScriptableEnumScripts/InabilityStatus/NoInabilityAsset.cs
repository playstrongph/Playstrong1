using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "NoInability", menuName = "SO's/Scriptable Enums/InabilityStatus/NoInability")]
    public class NoInabilityAsset : HeroInabilityAsset
    {

        public override IEnumerator StatusAction(ITurnController turnController)
        {

            var logicTree = turnController.GlobalTrees.MainLogicTree;
            
            logicTree.AddCurrent(turnController.StartHeroTurn());
            
            logicTree.EndSequence();
            yield return null;
        }
      

    }
}
