using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Actions.BaseClassScripts
{

    public class SkillActionAsset : ScriptableObject, IHeroAction
    {

        public virtual IEnumerator TargetHero(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public virtual IEnumerator StartAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.HeroLivingStatus.ReceiveHeroAction(this, thisHero, targetHero);
            
            logicTree.EndSequence();
            yield return null;
            
            logicTree.EndSequence();
            yield return null;

        }

       




    }
}
