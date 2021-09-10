using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class BasicActionAsset : ScriptableObject
    {
        public IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Implement in HeroLivingStatus - IBasicActionAsset
            //targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public virtual IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }

    }
}
