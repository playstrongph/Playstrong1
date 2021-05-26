using System.Collections.Generic;
using Logic;
using ScriptableObjects;
using UnityEngine;

public interface ISkillsPanel
{
    List<GameObject> SkillList { get; }

    ICoroutineTreesAsset CoroutineTreesAsset { get; }

    IUpdateHeroSkills UpdateHeroSkills { get; }
}