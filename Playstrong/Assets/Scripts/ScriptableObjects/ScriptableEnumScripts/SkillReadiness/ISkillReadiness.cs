using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.StandardActions;

namespace ScriptableObjects.Enums.SkillStatus
{
    public interface ISkillReadiness
    {
        void StatusAction(ISkillLogic skillLogic);

        void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero);

        void SkillStartAction(ISkillStandardActionAsset skillStandardActionAsset, IHero thisHero,
            IHero targetHero);

        void SkillStartAction(ISkillStandardActionAsset skillStandardActionAsset, IHero targetHero);
        
        
        /*void ResetSkillCooldown(ISkill skill);
       IEnumerator SetCdPassiveSkillReady(ISkillLogic skillLogic);*/
    }
}