using Logic;

namespace Interfaces
{
    public interface IHeroesListReference
    {
        IHeroesList LivingHeroes { get; }
        IHeroesList DeadHeroes { get; }

        IHeroesList HeroSkillsList { get; }


    }
}