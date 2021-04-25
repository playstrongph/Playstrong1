namespace Interfaces
{
    public interface IHeroLogicReferences
    {
        IHeroAttributes HeroAttributes { get; }

        ILoadHeroAttributes LoadHeroAttributes { get; }

    }
}