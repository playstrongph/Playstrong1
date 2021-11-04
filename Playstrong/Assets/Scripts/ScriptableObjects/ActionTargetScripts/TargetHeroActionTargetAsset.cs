using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargetScripts
{
    
    [CreateAssetMenu(fileName = "TargetHero", menuName = "SO's/ActionTargets/TargetHero")]
    public class TargetHeroActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            
            heroTargets.Clear();
            heroTargets.Add(targetHero);
            
            return heroTargets;
        }
        
        //Used by status effects
        public override List<IHero> GetHeroTargets(IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(targetHero);
            
            Debug.Log("Hero: " +heroTargets[0].HeroName);
            
            return heroTargets;
        }
        
        public override IHero GetHeroTarget(IHero thisHero, IHero targetHero)
        {
            Debug.Log("TargetHero2: " +targetHero.HeroName);
            return targetHero;
        }
        
        public override IHero GetHeroTarget(IHero targetHero)
        {
            Debug.Log("TargetHero1: " +targetHero.HeroName);
            return targetHero;
        }
            
    }
}
