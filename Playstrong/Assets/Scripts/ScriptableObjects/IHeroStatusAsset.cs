using Interfaces;
using Logic;

namespace ScriptableObjects
{
    public interface IHeroStatusAsset
    {

        void StatusAction(IHeroLogic heroLogic);
        void InitializeTurnController(ITurnController turnController);

    }
}