using System.Collections.Generic;
using ScriptableObjects.Others;
using UnityEngine;

namespace Logic
{
    public interface ISkillsPanel
    {
        List<GameObject> SkillList { get; }

        ICoroutineTreesAsset CoroutineTreesAsset { get; }

        IUpdateHeroSkills UpdateHeroSkills { get; }
    }
}