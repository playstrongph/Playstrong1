using GameSettings;
using Interfaces;
using ScriptableObjects;

namespace Logic
{
    public interface IBattleSceneManager
    {
        IBattleSceneSettings BattleSceneSettings { get; }
        ICoroutineTree LogicTree { get; set; }
        ICoroutineTree VisualTree { get; set; }
        ITurnController TurnController { get; }

        ICoroutineTreesAsset GlobalTrees { get; }

    }
}