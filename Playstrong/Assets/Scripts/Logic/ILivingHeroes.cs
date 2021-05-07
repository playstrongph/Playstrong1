using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface ILivingHeroes
    {
        List<GameObject> HeroesList { get; }
        Transform Transform { get; }
    }
}