using Interfaces;

namespace ScriptableObjects.HeroStatus
{
    public interface IHeroDeadAsset
    {
        void StatusAction(IHeroLogic heroLogic);
    }
}