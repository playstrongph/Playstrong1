using Interfaces;
using References;

namespace Logic
{
    public interface ITargetSkill
    {
        ISkill Skill { get; }
        ITargetPreview SkillPreview { get; }
        IDragSkillTarget DragSkillTarget { get; }
        IGetSkillTargets GetSkillTargets { get; }
    }
}