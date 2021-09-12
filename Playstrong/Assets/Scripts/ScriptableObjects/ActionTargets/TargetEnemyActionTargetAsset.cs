using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargets
{
    
    [CreateAssetMenu(fileName = "TargetEnemy", menuName = "SO's/ActionTargets/TargetEnemy")]
    public class TargetEnemyActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Get Hero Targets 2 args");
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(targetHero);
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero targetHero)
        {
            Debug.Log("Get Hero Targets 1 arg");
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(targetHero);
            
            return heroTargets;
        }
            
    }
}
