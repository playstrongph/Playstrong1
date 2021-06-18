using ScriptableObjects.Others;

namespace Logic
{
    public interface IReduceStatusEffectCounters
    {
        void ReduceCounters(int value, ICoroutineTreesAsset coroutineTreesAsset);
    }
}