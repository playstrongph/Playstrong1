using System.Collections.Generic;
using Interfaces;
using ScriptableObjects;
using ScriptableObjects.Others;
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
        int SpeedConstant { get; }
        int TimerFull { get; }

        bool FreezeTimers { get; set; }

        IBattleSceneManager BattleSceneManager { get; }

        IInitializeSkillEffects InitializeSkillEffects { get; }

        ISetHeroStatus SetHeroStatus { get; }
    }
}