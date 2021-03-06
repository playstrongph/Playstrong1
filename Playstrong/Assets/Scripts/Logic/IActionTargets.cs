using System.Collections.Generic;
using Interfaces;
using References;

namespace Logic
{
    public interface IActionTargets
    {
        
        //TEST
        List<IHero> PresetHeroTargets { get; set; }


        List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero);
        List<IHero> GetHeroTargets(IHero targetHero);
        IHero GetHeroTarget(IHero thisHero, IHero targetHero);
        IHero GetHeroTarget(IHero hero);
        IHero CustomHeroTarget { get; set; }
        
       
        IHero SetStatusEffectHero(IHeroStatusEffect heroStatusEffect);
        ISkill SetSkillReference(ISkill skill);
    }
}