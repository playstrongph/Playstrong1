using ScriptableObjects.StatusEffects;
using ScriptableObjects.StatusEffects.StatusEffectType;
using TMPro;
using UnityEngine.UI;
using Visual;

namespace Logic
{
    public interface IHeroStatusEffect
    {
        IStatusEffect StatusEffectAsset { get; set; }
        int Counters { get; set; }
        Image Icon { get; }
        TextMeshProUGUI CounterVisual { get; }

        IStatusEffectType StatusEffectType { get; set; }

        ILoadStatusEffectValues LoadStatusEffectValues { get; }
    }
}