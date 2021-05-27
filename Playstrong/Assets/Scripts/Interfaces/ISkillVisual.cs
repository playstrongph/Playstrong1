using References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Visual;

namespace Interfaces
{
    public interface ISkillVisual
    {
        ISkill Skill { get; }

        Canvas SkillCanvas { get; }

        GameObject SkillGlow { get; }

        Image SkillGraphic { get; }

        TextMeshProUGUI CooldownText { get; }

        ILoadSkillVisuals LoadSkillVisuals { get; }

        ISkillCooldownVisual SkillCooldownVisual { get; }
    }
}