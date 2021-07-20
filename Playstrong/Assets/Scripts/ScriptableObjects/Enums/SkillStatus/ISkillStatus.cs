using Interfaces;
using Logic;

namespace ScriptableObjects.Enums.SkillStatus
{
    public interface ISkillStatus
    {
        void StatusAction(ISkillLogic skillLogic);

        void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero);
    }
}