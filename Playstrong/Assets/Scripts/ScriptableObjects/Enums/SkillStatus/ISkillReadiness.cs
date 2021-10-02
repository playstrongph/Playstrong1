using System.Collections;
using Interfaces;
using Logic;
using References;

namespace ScriptableObjects.Enums.SkillStatus
{
    public interface ISkillReadiness
    {
        void StatusAction(ISkillLogic skillLogic);

        void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero);

        void ResetSkillCooldown(ISkill skill);

        IEnumerator SetActiveSkillReady(ISkillLogic skillLogic);

        IEnumerator SetCdPassiveSkillReady(ISkillLogic skillLogic);
    }
}