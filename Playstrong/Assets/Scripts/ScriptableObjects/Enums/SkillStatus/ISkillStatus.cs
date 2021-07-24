using System.Collections;
using Interfaces;
using Logic;
using References;

namespace ScriptableObjects.Enums.SkillStatus
{
    public interface ISkillStatus
    {
        void StatusAction(ISkillLogic skillLogic);

        void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero);

        void ResetSkillCooldown(ISkill skill);

        IEnumerator SetSkillReady(ISkillLogic skillLogic);
    }
}