using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;

namespace Logic
{
    public interface IUpdateSkillUseStatus
    {
        //ISkillUseStatusAsset UsingSkill { get; }
        //ISkillUseStatusAsset NotUsingSkill { get; }

        void SetHeroUsingSkill();

        void SetHeroNotUsingSkill();
        void SetHeroUsedSkillLastTurn();
        
        //TEST NEW - Nov 11 2021
        void SetUsingSkill();

        void SetUsedSkillLastTurn();
    }
}