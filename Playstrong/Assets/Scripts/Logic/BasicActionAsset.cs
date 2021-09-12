using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class BasicActionAsset : ScriptableObject, IBasicActionAsset
    {
        public IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
           
            targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);

            logicTree.EndSequence();
            yield return null;

        }
        
        public virtual IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator StartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Implement in HeroLivingStatus - IBasicActionAsset
            //targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public virtual IEnumerator TargetAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator StartAction(IHero hero, float value)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Implement in HeroLivingStatus - IBasicActionAsset
            //targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public virtual IEnumerator TargetAction(IHero hero, float value)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        

    }
}
