using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IHeroesList
    {
        List<GameObject> HeroList { get; }

        List<GameObject> GetList();
    }
}