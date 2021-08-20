using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.AnimationSOscripts
{
    public class GameAnimations : ScriptableObject, IGameAnimations
    {
        public virtual IEnumerator StartAnimation(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;


            visualTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator StartAnimation(IHero thisHero, IHero targetHero)
        {
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            
          
            
            visualTree.EndSequence();
            yield return null;
        }
    }
}
