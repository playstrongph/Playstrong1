using Interfaces;
using UnityEngine;

namespace ScriptableObjects
{
    public interface ICoroutineTreesAsset
    {
        ICoroutineTree MainLogicTree { get; set; }
        ICoroutineTree MainVisualTree { get; set; }
        
        //void InitTrees(MonoBehaviour mono);
    }
}