using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargets
{
    
    [CreateAssetMenu(fileName = "CustomTargetHero", menuName = "SO's/ActionTargets/CustomTargetHero")]
    public class CustomHeroActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            
            heroTargets.Clear();
            heroTargets.Add(CustomHeroTarget);
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero hero)
        {
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(CustomHeroTarget);
            
            return heroTargets;
        }
        
        public override IHero GetHeroTarget(IHero thisHero, IHero targetHero)
        {
            return CustomHeroTarget;
        }
        
        public override IHero GetHeroTarget(IHero hero)
        {
            return CustomHeroTarget;
        }
            
    }
}
