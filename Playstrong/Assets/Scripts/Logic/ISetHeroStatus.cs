using ScriptableObjects;

namespace Logic
{
    public interface ISetHeroStatus
    {
        IHeroStatusAsset HeroActive { get; }
        IHeroStatusAsset HeroInactive { get; }
        IHeroStatusAsset HeroDead { get; }
    }
}