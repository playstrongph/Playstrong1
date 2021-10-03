using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;

namespace Logic
{
    public interface IUpdateSkillEnabledStatus
    {
        ISkillEnabledStatus SkillEnabled { get; }
        ISkillEnabledStatus SkillDisabled { get; }
    }
}