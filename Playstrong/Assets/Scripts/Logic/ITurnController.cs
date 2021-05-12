using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface ITurnController
    {
        List<Object> HeroTimers { get; }
        List<Object> ActiveHeroes { get; }
        ICoroutineTree LogicTree { get; set; }
        ICoroutineTree VisualTree { get; set; }
        void StartTick();

        void EndTurn();
    }
}