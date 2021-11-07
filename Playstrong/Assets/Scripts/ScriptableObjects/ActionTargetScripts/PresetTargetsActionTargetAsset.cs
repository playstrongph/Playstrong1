using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "PresetHeroTargets", menuName = "SO's/ActionTargets/PresetHeroTargets")]
    public class PresetTargetsActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            if(PresetHeroTargets == null)
                Debug.Log("Null PresetHeroes");
            
            Debug.Log("GetHeroTargets2: " +PresetHeroTargets.Count);
            
            return PresetHeroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero thisHero)
        {
            if(PresetHeroTargets == null)
                Debug.Log("Null PresetHeroes");
            
            Debug.Log("GetHeroTargets1: " +PresetHeroTargets.Count);
            
            return PresetHeroTargets;
        }
        
        
            
    }
}
