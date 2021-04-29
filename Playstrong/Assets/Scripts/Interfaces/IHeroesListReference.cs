namespace Interfaces
{
    public interface IHeroesListReference
    {
        IHeroesList LivingHeroes { get; }
        IHeroesList DeadHeroes { get; }
    }
}