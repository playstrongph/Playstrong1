using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

    [CreateAssetMenu(fileName = "NoCounterUpdate", menuName = "SO's/Status Effects/Counters Update/NoCounterUpdate")]
    public class NoUpdateTimingAsset :  StatusEffectUpdateTimingAsset
    {
       
        public override void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect)
        {
           
        }

        public override void UpdateCountersEndTurn(IHeroStatusEffect heroStatusEffect)
        {
           
        }


    }
}
