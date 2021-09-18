using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.GameEvents;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCounterAttackActionAsset", menuName = "SO's/SkillActions/IncreaseCounterAttackActionAsset")]
    
    public class DealCounterAttackBasicAction : BasicActionAsset
    {
        private int chanceValue = 100;
        private int resistanceValue = 1000;
        
        [SerializeField]
        private List<ScriptableObject> standardEvents = new List<ScriptableObject>();

        private List<IStandardEvent> StandardEvents
        {
            get
            {
                var newStandardEvents = new List<IStandardEvent>();
                foreach (var standardEventObject in standardEvents)
                {
                    var standardEvent = standardEventObject as IStandardEvent;
                    newStandardEvents.Add(standardEvent);
                }

                return newStandardEvents;
            }
        }

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackChance += chanceValue;
            
            logicTree.EndSequence();
            yield return null;
        }

        private void TemporaryCounterResistanceIncrease(IHero targetHero)
        {
            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance += resistanceValue;
        }
        
        private void RemoveTemporaryCounterResistanceIncrease(IHero targetHero)
        {
            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance -= resistanceValue;
        }
        
       











    }
}
