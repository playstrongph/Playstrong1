using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface IPanelSkills
    {
        List<GameObject> List { get; }
        Transform Transform { get; }

        IEnumerator DisablePanelSkillTargetVisual(ICoroutineTree tree);

    }
}