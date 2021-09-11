using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class ActionTargetsAsset : ScriptableObject, IActionTargets
    {

        public virtual List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var heroTargets = new List<IHero>();
          
            
            //Example - targetHero
            //heroTargets.Add(targetHero);
            
            //Example - thisHero
            //heroTargets.Add(targetHero);
            
            //Example - all allies
            //var allyHeroes = thisHero.AllAllyHeroes;
            //heroTargets = new List<IHero>(allyHeroes);
            
            return heroTargets;
        }
        
        public virtual List<IHero> GetHeroTargets(IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            return heroTargets;
        }


    }
}
