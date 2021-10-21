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
            heroTargets.Add(LocalSkill.Hero);
            
            Debug.Log("Skill Caster Hero2: " +LocalSkill.Hero.HeroName );
            
            return heroTargets;
        }
        
        public override List<IHero> GetHeroTargets(IHero hero)
        {
            var heroTargets = new List<IHero>();
            heroTargets.Clear();

            Debug.Log("Skill Caster Hero1: " +LocalSkill.Hero.HeroName );
            
            heroTargets.Add(LocalSkill.Hero);
            
            return heroTargets;
        }
        
        public override IHero GetHeroTarget(IHero thisHero, IHero targetHero)
        {
            return LocalSkill.Hero;
        }
        
        public override IHero GetHeroTarget(IHero hero)
        {
            return LocalSkill.Hero;
        }
        
        //Called by LoadStatusEffectValues
        public override ISkill SetSkillReference(ISkill skill)
        {
            LocalSkill = skill;
            Debug.Log("Set Skill Caster Reference: " +LocalSkill.SkillName);

            return LocalSkill;
        }
       
            
    }
}
