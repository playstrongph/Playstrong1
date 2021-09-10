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
        /*[SerializeField] private ScriptableObject gameEvent;
        private IGameEvents GameEvent => gameEvent as IGameEvents;*/

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


        public IEnumerator RegisterStandardAction(IHero thisHero, IHero targetHero)
        {
            //TODO: GameEvent.SubscribeStandardAction( IStandardAction stdAction)
            
            yield return null;
        }




        public IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {   
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Standard ConditionCheck
            targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Should only be accessed by AliveLivingHero.DoHeroAction
        /// </summary>
        public virtual IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;   
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// StartAction for StatusEffects
        /// </summary>
        public IEnumerator StartAction(IHero targetHero, float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;   

            //TODO: Standard ConditionCheck
            targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, targetHero, value);

            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator TargetAction(IHero targetHero, float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }

    }
}
