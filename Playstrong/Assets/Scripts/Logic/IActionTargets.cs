﻿using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IActionTargets
    {
        List<IHero> GetHeroTargets(IHero thisHero, IHero targetHero);
        List<IHero> GetHeroTargets(IHero targetHero);
        IHero GetHeroTarget(IHero thisHero, IHero targetHero);
        IHero GetHeroTarget(IHero hero);
    }
}