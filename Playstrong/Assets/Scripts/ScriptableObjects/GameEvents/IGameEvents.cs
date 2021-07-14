using Interfaces;
using References;

namespace ScriptableObjects.GameEvents
{
    public interface IGameEvents
    {
        void SubscribeToHeroEvents(IHero hero);

        void SubscribeToSkillEvents(ISkill skill);
    }
}