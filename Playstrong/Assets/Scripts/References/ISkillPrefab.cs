using Interfaces;
using Logic;
using Visual;

namespace References
{
    public interface ISkillPrefab
    {
        ISkillLogic SkillLogic { get; }
        ISkillVisual SkillVisual { get; }
        ISkillPreviewVisual SkillPreviewVisual { get; }
    }
}