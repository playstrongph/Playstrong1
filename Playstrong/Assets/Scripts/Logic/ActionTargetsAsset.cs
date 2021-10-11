﻿using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class ActionTargetsAsset : ScriptableObject, IActionTargets
    {

        public IHero CustomHeroTarget { get; set; }
        
        //TEST
        protected IHero LocalHero;

        //From SINGLE to Multiple target requirements - used in StandardActions
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
        
        //For SINGLE target requirements - used in damage calculations
        public virtual IHero GetHeroTarget(IHero thisHero, IHero targetHero)
        {
            //Example only - can return either this or target hero
            return targetHero;
            //return thisHero;
        }
        
        public virtual IHero GetHeroTarget(IHero hero)
        {
            //Example only
            return hero;
        }
        
        //TEST
        public virtual IHero SetStatusEffectHero(IHeroStatusEffect heroStatusEffect)
        {
            return LocalHero;
        }


    }
}
