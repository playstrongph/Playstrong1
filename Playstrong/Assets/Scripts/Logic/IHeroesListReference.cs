using Interfaces;

namespace Logic
{
    public interface IHeroesListReference
    {
        IHeroesList LivingHeroes { get; }
        IHeroesList DeadHeroes { get; }
    }
}