using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface IDeadHeroes
    {
        List<GameObject> HeroesList { get; }
        Transform Transform { get; }

        List<IHero> DeadHeroesList { get; }
    }
}