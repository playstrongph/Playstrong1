namespace Interfaces
{
    public interface IHeroLogicReferences
    {

        IHeroObjectReferences HeroObjectReferences { get; }
        IHeroAttributes HeroAttributes { get;}

        ILoadHeroAttributes LoadHeroAttributes { get; }

    }
}