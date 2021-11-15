using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public interface ITargetSkill
    {
        ISkill Skill { get; }
        ITargetPreview SkillPreview { get; }
        IDragSkillTarget DragSkillTarget { get; }
        IGetSkillTargets GetSkillTargets { get; }

        GameObject TargetSkillGameObject { get; }
    }
}