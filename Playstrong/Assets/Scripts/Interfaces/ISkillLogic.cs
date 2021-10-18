using Logic;
using References;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using ScriptableObjects.SkillEffects;
using Visual;

namespace Interfaces
{
    public interface ISkillLogic
    {
        ISkillAttributes SkillAttributes { get; }
        ILoadSkillAttributes LoadSkillAttributes { get; }
        ISkill Skill { get; }
        IUpdateSkillReadiness UpdateSkillReadiness { get; }
        ISkillEvents SkillEvents { get; }
        IChangeSkillCooldown ChangeSkillCooldown { get; }

        IUpdateSkillEnabledStatus UpdateSkillEnabledStatus { get; }

        ISkillOtherAttributes SkillOtherAttributes { get; }
        IUpdateSkillUseStatus UpdateSkillUseStatus { get; }

    }
}