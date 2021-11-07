using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    /// <summary>
    /// Used when you need the same random targets across different standard actions
    /// Usually because of different basic conditions for the standard actions
    /// </summary>
    [CreateAssetMenu(fileName = "RandomizeLivingAlliesList", menuName = "SO's/BasicActions/RandomizeLivingAlliesList")]
    public class RandomizeLivingAlliesBasicActionAsset : BasicActionAsset
    {
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //You'll only use either 'all' or 'allOther' lists one at a time
            targetHero.ShuffleAllLivingAllyHeroes();
            
            //You'll only use either 'all' or 'allOther' lists one at a time
            targetHero.ShuffleOtherLivingAllyHeroes();

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //You'll only use either 'all' or 'allOther' lists one at a time
            targetHero.ShuffleAllLivingAllyHeroes();
            
            //You'll only use either 'all' or 'allOther' lists one at a time
            targetHero.ShuffleOtherLivingAllyHeroes();
            
            logicTree.EndSequence();
            yield return null;
        }
        
       
      










    }
}
