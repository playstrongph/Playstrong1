using Interfaces;
using Logic;
using Visual;

namespace References
{
    public interface ISkillObjectReferences
    {
        ISkillLogicReferences SkillLogicReferences { get; }
        ISkillVisualReferences SkillVisualReferences { get; }
        ISkillPreviewVisual HeroPreviewVisual { get; }
    }
}