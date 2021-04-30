using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IHeroPortraitList
    {
        List<GameObject> GetList();

        List<GameObject> HeroList { get; }

        Transform GetTransform();
    }
}