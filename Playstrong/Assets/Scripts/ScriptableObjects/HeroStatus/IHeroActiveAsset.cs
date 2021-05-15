using Interfaces;

namespace ScriptableObjects.HeroStatus
{
    public interface IHeroActiveAsset
    {
        void StatusAction(IHeroLogic heroLogic);
    }
}