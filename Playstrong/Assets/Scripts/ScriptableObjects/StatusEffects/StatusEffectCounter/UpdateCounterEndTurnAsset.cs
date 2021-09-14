using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

    [CreateAssetMenu(fileName = "UpdateCounterEndTurnAsset", menuName = "SO's/Status Effects/Counters Update/UpdateCounterEndTurnAsset")]
    public class UpdateCounterEndTurnAsset : StatusEffectCounterUpdateAsset
    {
        private ICoroutineTree _logicTree;

        public override void UpdateCountersEndTurn(IHeroStatusEffect heroStatusEffect)
        {
            var logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UpdateCountersCoroutine(heroStatusEffect));
        }






    }
}
