using ScriptableObjects.Others;

namespace Logic
{
    public interface IDecreaseStatusEffectCounters
    {
        void DecreaseCounters(int value, ICoroutineTreesAsset coroutineTreesAsset);
    }
}