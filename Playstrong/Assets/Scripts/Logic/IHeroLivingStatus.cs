using ScriptableObjects.HeroLivingStatus;

namespace Logic
{
    public interface IHeroLivingStatus
    {
        IHeroLivingStatusAsset HeroAliveStatus { get; }
        IHeroLivingStatusAsset HeroDeadStatus { get; }
    }
}