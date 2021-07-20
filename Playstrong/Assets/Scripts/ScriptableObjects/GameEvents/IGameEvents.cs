using Interfaces;
using References;
using ScriptableObjects.Enums.SkillStatus;

namespace ScriptableObjects.GameEvents
{
    public interface IGameEvents
    {
        void SubscribeToHeroEvents(IHero hero);

        void SubscribeToSkillEvents(ISkill skill);
        
        //TEST
        ISkillStatus SkillReadinessReference { get; set; }
        ISkillAttributes SkillAttributes { get; set; }
        //TEST END
        
    }
}