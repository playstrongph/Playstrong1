using Interfaces;
using Logic;
using Visual;

namespace References
{
    public interface ISkillPrefab
    {
        ISkillLogic SkillLogic { get; }
        ISkillVisualReferences SkillVisualReferences { get; }
        ISkillPreviewVisual SkillPreviewVisual { get; }
    }
}