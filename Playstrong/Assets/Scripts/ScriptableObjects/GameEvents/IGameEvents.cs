using Interfaces;

namespace ScriptableObjects.GameEvents
{
    public interface IGameEvents
    {
        void SubscribeToEvent(IHero hero);
    }
}