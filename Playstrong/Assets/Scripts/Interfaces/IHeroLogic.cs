namespace Interfaces
{
    public interface IHeroLogic
    {

        IHeroObjectReferences HeroObjectReferences { get; }
        IHeroAttributes HeroAttributes { get;}

        ILoadHeroAttributes LoadHeroAttributes { get; }

    }
}