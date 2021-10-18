using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;

namespace Logic
{
    public interface IUpdateSkillUseStatus
    {
        ISkillUseStatusAsset UsingSkill { get; }
        ISkillUseStatusAsset NotUsingSkill { get; }
    }
}