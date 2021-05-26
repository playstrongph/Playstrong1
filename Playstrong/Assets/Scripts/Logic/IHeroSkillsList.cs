using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Logic
{
    public interface IHeroSkillsList
    {
        List<GameObject> SkillList { get; }

        ICoroutineTreesAsset CoroutineTreesAsset { get; }

        IUpdateHeroSkills UpdateHeroSkills { get; }
    }
}