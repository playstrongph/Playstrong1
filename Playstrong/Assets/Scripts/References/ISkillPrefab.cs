﻿using Interfaces;
using Logic;
using Visual;

namespace References
{
    public interface ISkillPrefab
    {
        ISkillLogicReferences SkillLogicReferences { get; }
        ISkillVisualReferences SkillVisualReferences { get; }
        ISkillPreviewVisual SkillPreviewVisual { get; }
    }
}