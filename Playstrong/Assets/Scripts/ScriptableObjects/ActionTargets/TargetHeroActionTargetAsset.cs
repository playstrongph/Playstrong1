using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargets
{
    
    [CreateAssetMenu(fileName = "TargetEnemy", menuName = "SO's/ActionTargets/TargetEnemy")]
    public class TargetHeroActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(targetHero);
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(targetHero);
            
            return heroTargets;
        }
            
    }
}
