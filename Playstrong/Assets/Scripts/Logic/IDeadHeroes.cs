using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IDeadHeroes
    {
        List<GameObject> HeroesList { get; }
        Transform Transform { get; }
    }
}