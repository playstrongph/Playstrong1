using Interfaces;

namespace ScriptableObjects.HeroStatus
{
    public interface IHeroInactiveAsset
    {
        void StatusAction(IHeroLogic heroLogic);
    }
}