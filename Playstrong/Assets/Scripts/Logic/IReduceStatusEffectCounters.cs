using ScriptableObjects.Others;

namespace Logic
{
    public interface IReduceStatusEffectCounters
    {
        void ReduceCounters(ICoroutineTreesAsset coroutineTreesAsset);
    }
}