using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Logic
{
    public class ActionTargetsAsset : ScriptableObject, IActionTargets
    {

        public IHero CustomHeroTarget { get; set; }
        
        //STATUS EFFECT HERO
        protected IHero LocalHero;
        
        //SKILL REFERENCE
        protected ISkill LocalSkill;

        //From SINGLE to Multiple target requirements - used in StandardActions
        public virtual List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            
            Debug.Log("Wrong Assignment - Null Hero List");

            return heroTargets;
        }
        
        public virtual List<IHero> GetHeroTargets(IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            
            Debug.Log("Wrong Assignment - Null Hero List");
            
            return heroTargets;
        }
        
        //For SINGLE target requirements - used in damage calculations
        public virtual IHero GetHeroTarget(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Wrong Assignment - Null Hero List");
            return null;
            //return thisHero;
        }
        
        public virtual IHero GetHeroTarget(IHero hero)
        {
            Debug.Log("Wrong Assignment - Null Hero List");
            return null;
        }
        
        //TEST
        public virtual IHero SetStatusEffectHero(IHeroStatusEffect heroStatusEffect)
        {
            return LocalHero;
        }
        
        public virtual ISkill SetSkillReference(ISkill skill)
        {
            LocalSkill = skill;
            return LocalSkill;
        }


    }
}
