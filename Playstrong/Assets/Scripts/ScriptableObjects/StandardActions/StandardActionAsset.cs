using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.GameEvents;
using UnityEngine;

namespace ScriptableObjects.StandardActions
{
    public class StandardActionAsset : ScriptableObject, IStandardActionAsset
    {

       
        
        

        //TODO: Set StandardEvent Reference to this asset
        
        //TODO: Standard Action Method

        
         
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
        public virtual IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
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
        
        public virtual IEnumerator ActionTarget(IHero targetHero, float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }

    }
}
