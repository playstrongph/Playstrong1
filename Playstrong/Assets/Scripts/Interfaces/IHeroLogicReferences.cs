namespace Interfaces
{
    public interface IHeroLogicReferences
    {
        IHeroAttributes HeroAttributes { get; set; }

        ILoadHeroAttributes LoadHeroAttributes { get; set; }

    }
}