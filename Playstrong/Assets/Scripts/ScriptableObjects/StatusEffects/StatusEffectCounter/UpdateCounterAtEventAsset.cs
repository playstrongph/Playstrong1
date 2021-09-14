using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.GameEvents;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

    [CreateAssetMenu(fileName = "UpdateCounterAtEvent", menuName = "SO's/Status Effects/Counters Update/UpdateCounterAtEvent")]
    public class UpdateCounterAtEventAsset :  StatusEffectCounterUpdateAsset
    {
        private ICoroutineTree _logicTree;
        
        [SerializeField]
        private ScriptableObject standardEvent;
        private IStandardEvent StandardEvent => standardEvent as IStandardEvent;

        private IHeroStatusEffect _heroStatusEffect;

        public override void UpdateCountersAtEvent(IHeroStatusEffect heroStatusEffect)
        {
            _heroStatusEffect = heroStatusEffect;
            StandardEvent.SubscribeStatusEffectCountersUpdate(heroStatusEffect);
        }

        public override void UpdateCounterAction(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_heroStatusEffect.StatusEffectCounterUpdate.UpdateCountersCoroutine(_heroStatusEffect));
        }
        
        public override void UpdateCounterAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_heroStatusEffect.StatusEffectCounterUpdate.UpdateCountersCoroutine(_heroStatusEffect));
        }


       


    }
}
