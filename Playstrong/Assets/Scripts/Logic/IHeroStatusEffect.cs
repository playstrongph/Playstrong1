using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using ScriptableObjects.StatusEffects.Instance;
using ScriptableObjects.StatusEffects.StatusEffectCounter;
using ScriptableObjects.StatusEffects.StatusEffectType;
using TMPro;
using UnityEngine.UI;
using Visual;

namespace Logic
{
    public interface 
        IHeroStatusEffect
    {
        IStatusEffectAsset StatusEffectAsset { get; set; }
        int Counters { get; set; }
        Image Icon { get; }
        TextMeshProUGUI CounterVisual { get; }

        IStatusEffectType StatusEffectType { get; set; }

        ILoadStatusEffectValues LoadStatusEffectValues { get; }
        
        ICoroutineTreesAsset CoroutineTreesAsset { get; set; }

        IReduceStatusEffectCounters ReduceStatusEffectCounters { get; }

        ISetStatusEffectCounters SetStatusEffectCounters { get; }

        IStatusEffectCounterUpdate StatusEffectCounterUpdate { get; set; }

        IStatusEffectInstance StatusEffectInstance { get; set; }


    }
}