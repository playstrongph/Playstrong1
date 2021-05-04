namespace Interfaces
{
    public interface IHeroLogic
    {

        IHeroPrefab HeroPrefab { get; }
        IHeroAttributes HeroAttributes { get;}

        ILoadHeroAttributes LoadHeroAttributes { get; }

    }
}