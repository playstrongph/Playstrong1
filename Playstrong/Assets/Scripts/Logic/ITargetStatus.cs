using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface ITargetStatus
    {
        void AddToTargetList(IHero hero, List<IHero> enemyHeroes, List<IHero> enemyTauntHeroes,
            List<IHero> enemyStealthHeroes);
    }
}