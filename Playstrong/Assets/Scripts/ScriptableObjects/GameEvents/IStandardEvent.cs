using Interfaces;
using ScriptableObjects.StandardActions;

namespace ScriptableObjects.GameEvents
{
    public interface IStandardEvent
    {
        void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction);
        void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction);
    }
}