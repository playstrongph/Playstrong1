﻿using References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Visual;

namespace Interfaces
{
    public interface ISkillPreviewVisual
    {
        ISkillObjectReferences SkillObjectReferences { get; }

        Canvas PreviewCanvas { get; }

        Image PreviewImage { get; }

        TextMeshProUGUI Cooldown { get; }

        TextMeshProUGUI PreviewName { get; }

        TextMeshProUGUI Description { get; }

        ILoadSkillPreviewVisuals LoadSkillPreviewVisuals { get; }
        
        Transform PreviewTransform { get; }

    }
}