using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public interface ILivingHeroes
    {
        List<GameObject> HeroesList { get; }
        Transform Transform { get; }

        IPanelPortaitAndSkillDisplay PanelPortaitAndSkillDisplay { get; }

        IPlayer Player { get; }

        List<IHero> LivingHeroesList { get; }


    }
}