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
    [CreateAssetMenu(fileName = "PresetActionTargets", menuName = "SO's/BasicActions/PresetActionTargets")]
    public class PresetActionTargetsBasicActionAsset : BasicActionAsset
    {

        [SerializeField] private ScriptableObject presetTargets;
        private IActionTargets PresetTargets  => presetTargets as IActionTargets;
        
        [SerializeField] private ScriptableObject actionTargets;
        
        private IActionTargets ActionTargets  => actionTargets as IActionTargets;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            PresetTargets.PresetHeroTargets = ActionTargets.GetHeroTargets(targetHero);
            
            Debug.Log("PresetAction 1: " + PresetTargets.PresetHeroTargets.Count);
            
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            PresetTargets.PresetHeroTargets = ActionTargets.GetHeroTargets(thisHero, targetHero);
           
            Debug.Log("PresetAction 2: " + PresetTargets.PresetHeroTargets.Count);
            
            logicTree.EndSequence();
            yield return null;
        }
        
       
      










    }
}
