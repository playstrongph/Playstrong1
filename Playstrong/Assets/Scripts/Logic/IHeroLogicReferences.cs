using Interfaces;

namespace Logic
{
    public interface IHeroLogicReferences
    {
        IHeroAttributes HeroAttributes { get; }

        ILoadHeroAttributes LoadHeroAttributes { get; }

    }
}