using Interfaces;
using Logic;
using ScriptableObjects;
using Visual;

namespace References
{
    public interface ISkill
    {
        ISkillLogic SkillLogic { get; }
        ISkillVisual SkillVisual { get; }
        ISkillPreviewVisual SkillPreviewVisual { get; }

        ITargetPreview TargetSkillPreview { get; }

        ICoroutineTreesAsset CoroutineTreesAsset { get; }
    }
}