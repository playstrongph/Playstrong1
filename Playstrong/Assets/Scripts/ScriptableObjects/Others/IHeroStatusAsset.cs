using Interfaces;
using Logic;

namespace ScriptableObjects.Others
{
    public interface IHeroStatusAsset
    {

        void StatusAction(IHeroLogic heroLogic);
        void InitializeTurnController(ITurnController turnController);

    }
}