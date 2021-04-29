using References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Interfaces
{
    public interface ISkillVisualReferences
    {
        ISkillObjectReferences SkillObjectReferences { get; }

        Canvas SkillCanvas { get; }

        GameObject SkillGlow { get; }

        Image SkillGraphic { get; }

        TextMeshProUGUI CooldownText { get; }
    }
}