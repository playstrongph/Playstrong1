using System.Collections.Generic;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Logic
{
    public interface ITurnController
    {
        List<Object> HeroTimers { get; }
        List<Object> ActiveHeroes { get; }

        ICoroutineTreesAsset GlobalTrees { get; }

        void StartHeroTurns();
        void EndTurn();
    }
}