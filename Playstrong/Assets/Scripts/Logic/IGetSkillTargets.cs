using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IGetSkillTargets
    {
        List<IHero> GetValidTargets();
    }
}