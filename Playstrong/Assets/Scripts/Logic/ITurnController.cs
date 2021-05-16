using System.Collections.Generic;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Logic
{
    public interface ITurnController
    {
        List<Object> HeroTimers { get; }

        int SpeedConstant { get; }

        int TimerFull { get; }

        bool FreezeTimers { get; set; }
        List<Object> ActiveHeroes { get; }
        
        void StartHeroTurns();

        void EndTurn();

        ICoroutineTreesAsset GlobalTrees { get; }

    }
}