﻿using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

    [CreateAssetMenu(fileName = "UpdateCounterStartTurn", menuName = "SO's/Status Effects/Counters Update/UpdateCounterStartTurn")]
    public class UpdateCounterStartTurnAsset :  StatusEffectCounterUpdateAsset
    {
        private ICoroutineTree _logicTree;

        public override void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect)
        {
            var logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UpdateCountersCoroutine(heroStatusEffect));
        }

        






    }
}
