using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IHeroesSkills
    {
        List<GameObject> List { get; }
        Transform Transform { get; }
    }
}