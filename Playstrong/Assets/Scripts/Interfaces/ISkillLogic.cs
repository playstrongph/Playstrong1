using Logic;
using References;
using ScriptableObjects.SkillEffects;
using Visual;

namespace Interfaces
{
    public interface ISkillLogic
    {
        ISkillAttributes SkillAttributes { get; }

        ILoadSkillAttributes LoadSkillAttributes { get; }

        ISkill Skill { get; }

        IReduceSkillCooldown ReduceSkillCooldown { get; }
        
        IResetSkillCooldown ResetSkillCooldown { get; }

        IUpdateSkillStatus UpdateSkillStatus { get; }

        IInitializePassiveSkill InitializePassiveSkill { get; }



    }
}