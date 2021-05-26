using References;
using Visual;

namespace Interfaces
{
    public interface ISkillLogic
    {
        ISkillAttributes SkillAttributes { get; }

        ILoadSkillAttributes LoadSkillAttributes { get; }

        ISkill Skill { get; }
    }
}