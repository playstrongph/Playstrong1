using System.Collections.Generic;
using Interfaces;
using References;

namespace Logic
{
    public interface IGetAllHeroSkills
    {
        List<ISkill> HeroSkills(IHero hero);
    }
}