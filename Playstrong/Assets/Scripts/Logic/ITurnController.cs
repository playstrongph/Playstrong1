using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface ITurnController
    {
        List<Object> HeroTimers { get; }
        List<Object> ActiveHeroes { get; }
        
        void StartTick();

        void EndTurn();
    }
}