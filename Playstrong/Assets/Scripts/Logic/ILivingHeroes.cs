using System.Collections.Generic;
using UnityEngine;
using Visual;

namespace Logic
{
    public interface ILivingHeroes
    {
        List<GameObject> HeroesList { get; }
        Transform Transform { get; }

        IPanelPortaitAndSkillDisplay PanelPortaitAndSkillDisplay { get; }
    }
}