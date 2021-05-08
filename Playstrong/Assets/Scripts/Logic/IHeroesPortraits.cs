using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IHeroesPortraits
    {
        List<GameObject> List { get; }
        Transform Transform { get; }
    }
}