using System.Collections;
using Interfaces;
using Logic;
using References;
using TMPro;

namespace ScriptableObjects.Enums.SkillType
{
    public interface ISkillType
    {
        //int SkillCdIndex { get; }
        void SkillCooldownDisplay(TextMeshProUGUI cooldown);

        void ReduceSkillCd(ISkill skill, int counter);

        void ResetActiveSkillCd(ISkill skill);
        
        IEnumerator SetSkillReady(ISkillLogic skillLogic);

        IEnumerator SetSkillNotReady(ISkillLogic skillLogic);

        IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter);

        IEnumerator DisableActiveSkill(ISkill skill);

        IEnumerator EnableActiveSkill(ISkill skill);

        IEnumerator DisablePassiveSkill(ISkill skill);

        IEnumerator EnablePassiveSkill(ISkill skill);
        
        IEnumerator HeroUsingPassiveSkill(ISkill skill);

        IEnumerator HeroUsedPassiveSkill(ISkill skill);

        IEnumerator HeroUsingActiveOrBasicSkill(ISkill skill);

        IEnumerator HeroUsedActiveOrBasicSkill(ISkill skill);

        void ResetCdPassiveSkillCd(ISkill skill);
        
        
        //NEW TEST - 20 Nov 2021
        ISkillType GetBasicSKill();

    }
}