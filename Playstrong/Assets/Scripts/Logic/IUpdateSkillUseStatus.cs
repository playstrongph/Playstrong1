using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;

namespace Logic
{
    public interface IUpdateSkillUseStatus
    {
        //ISkillUseStatusAsset UsingSkill { get; }
        //ISkillUseStatusAsset NotUsingSkill { get; }

        void SetHeroUsingPassiveSkill();

        void SetHeroNotUsingSkill();
        void SetHeroUsedPassiveSkill();
        
        //TEST NEW - Nov 11 2021
        void SetUsingSkill();

        void SetUsedSkillLastTurn();
    }
}