using Logic;

namespace Interfaces
{
    public interface IHeroLogic
    {

        IHero Hero { get; }
        IHeroAttributes HeroAttributes { get;}

        ILoadHeroAttributes LoadHeroAttributes { get; }

        IHeroTimer HeroTimer { get; }

        ISetHeroActive SetHeroActive { get; }

    }
}