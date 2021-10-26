using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.ActionTargets
{
    
    [CreateAssetMenu(fileName = "ThisHero", menuName = "SO's/ActionTargets/ThisHero")]
    public class ThisHeroActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            
            var heroTargets = new List<IHero>();
            
            heroTargets.Clear();
            heroTargets.Add(thisHero);
            
            //Debug.Log("Hero: " +heroTargets[0].HeroName);
            
            return heroTargets;
        }
        
        //Same as TargetHero for Single Arg
        public override List<IHero> GetHeroTargets(IHero hero)
        {
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(hero);
            
            return heroTargets;
        }

        public override IHero GetHeroTarget(IHero thisHero, IHero targetHero)
        {
            return thisHero;
        }
        
        public override IHero GetHeroTarget(IHero hero)
        {
            return hero;
        }

    }
}
