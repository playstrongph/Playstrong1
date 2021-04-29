using Visual;

namespace Interfaces
{
    public interface ISkillLogicReferences
    {
        ISkillAttributes SkillAttributes { get; }

        ILoadSkillAttributes LoadSkillAttributes { get; }
    }
}