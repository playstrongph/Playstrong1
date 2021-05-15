using Logic;
using ScriptableObjects;

namespace Interfaces
{
    public interface IHeroLogic
    {

        IHeroStatusAsset HeroStatus { get; set; }

        IHero Hero { get; }
        IHeroAttributes HeroAttributes { get;}

        ILoadHeroAttributes LoadHeroAttributes { get; }

        IHeroTimer HeroTimer { get; }

        ISetHeroActive SetHeroActive { get; }

    }
}