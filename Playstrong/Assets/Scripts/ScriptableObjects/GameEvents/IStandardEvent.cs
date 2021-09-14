using Interfaces;
using Logic;
using References;
using ScriptableObjects.StandardActions;
using ScriptableObjects.StatusEffects;

namespace ScriptableObjects.GameEvents
{
    public interface IStandardEvent
    {
        void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction);
        void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction);
        
        void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction);
        void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction);

        void SubscribeStatusEffectCountersUpdate(IHeroStatusEffect statusEffect);

        void UnsubscribeStatusEffectCountersUpdate(IHeroStatusEffect statusEffect);
    }
}