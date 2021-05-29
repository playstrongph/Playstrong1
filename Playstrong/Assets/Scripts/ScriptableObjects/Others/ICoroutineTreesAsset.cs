using Interfaces;

namespace ScriptableObjects.Others
{
    public interface ICoroutineTreesAsset
    {
        ICoroutineTree MainLogicTree { get; set; }
        ICoroutineTree MainVisualTree { get; set; }
        
        //void InitTrees(MonoBehaviour mono);
    }
}