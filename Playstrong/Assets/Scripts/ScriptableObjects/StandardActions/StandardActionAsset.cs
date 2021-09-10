using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.GameEvents;
using UnityEngine;

namespace ScriptableObjects.StandardActions
{
    public class StandardActionAsset : ScriptableObject, IStandardActionAsset
    {
        [SerializeField] private ScriptableObject standardEvent;
        private IStandardEvent StandardEvent => standardEvent as IStandardEvent;

        [SerializeField] private List<ScriptableObject> standardConditions = new List<ScriptableObject>();
        private List<IStandardConditionAsset> StandardConditions
        {
            get
            {
                var newStandardConditions = new List<IStandardConditionAsset>();
                foreach (var standardConditionObject in standardConditions)
                {
                    var standardCondition = standardConditionObject as IStandardConditionAsset;
                    
                    newStandardConditions.Add(standardCondition);
                }

                return newStandardConditions;
            }
        }


        public IEnumerator RegisterStandardAction(IHero hero)
        {
            //TODO: StandardEvent.SubscribeStandardAction( IStandardAction stdAction)
            StandardEvent.SubscribeStandardAction(hero, this);
            
            yield return null;
        }

        public void StartAction(IHero hero)
        {   
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(StartActionCoroutine(hero));

            logicTree.EndSequence();
            
        }

        private IEnumerator StartActionCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Foreach target in ActionTargets 

            foreach (var standardCondition in StandardConditions)
            {
                logicTree.AddCurrent(standardCondition.StartAction(hero));
            }
            
            logicTree.EndSequence();
            yield return null;
        }



    }
}
