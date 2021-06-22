using ScriptableObjects.Others;

namespace Logic
{
    public interface ISetStatusEffectCounters
    {
        void SetCounters(int value, ICoroutineTreesAsset coroutineTreesAsset);
    }
}