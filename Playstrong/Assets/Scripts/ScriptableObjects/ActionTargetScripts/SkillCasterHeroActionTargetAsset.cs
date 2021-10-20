using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.ActionTargets
{
    
    [CreateAssetMenu(fileName = "SkillCasterHero", menuName = "SO's/ActionTargets/SkillCasterHero")]
    public class SkillCasterHeroActionTargetAsset : ActionTargetsAsset
    {
        public override List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero)
        {
            var heroTargets = new List<IHero>();
            
            heroTargets.Clear();
            heroTargets.Add(SkillLocalHero);
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero hero)
        {
            var heroTargets = new List<IHero>();
            heroTargets.Clear();
            
            heroTargets.Add(SkillLocalHero);
            
            return heroTargets;
        }
        
        public override IHero GetHeroTarget(IHero thisHero, IHero targetHero)
        {
            return SkillLocalHero;
        }
        
        public override IHero GetHeroTarget(IHero hero)
        {
            return SkillLocalHero;
        }
        
        //Called by LoadStatusEffectValues
        public override IHero SetSkillReferenceHero(ISkill skill)
        {
            SkillLocalHero = skill.Hero;
            return SkillLocalHero;
        }
       
            
    }
}
