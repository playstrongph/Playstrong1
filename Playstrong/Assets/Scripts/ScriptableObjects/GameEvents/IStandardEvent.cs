using Interfaces;
using References;
using ScriptableObjects.StandardActions;

namespace ScriptableObjects.GameEvents
{
    public interface IStandardEvent
    {
        void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction);
        void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction);
        
        void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction);
        void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction);
    }
}