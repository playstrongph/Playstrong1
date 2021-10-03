using ScriptableObjects.Enums.SkillStatus;

namespace Logic
{
    public interface IUpdateSkillEnabledStatus
    {
        ISkillEnabledStatus SkillEnabled { get; }
        ISkillEnabledStatus SkillDisabled { get; }
    }
}