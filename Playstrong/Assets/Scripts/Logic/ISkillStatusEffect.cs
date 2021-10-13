using Interfaces;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using ScriptableObjects.StatusEffects.Instance;
using ScriptableObjects.StatusEffects.StatusEffectCounter;
using ScriptableObjects.StatusEffects.StatusEffectType;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Visual;

namespace Logic
{
    public interface ISkillStatusEffect
    {
        string Name { get; set; }
        int Counters { get; set; }
        Image Icon { get; }
        TextMeshProUGUI CounterVisual { get; }
        
       
        ISkillStatusEffectAsset SkillStatusEffectAsset { get; set; }
        
        IStatusEffectType StatusEffectType { get; set; }
        ILoadStatusEffectValues LoadStatusEffectValues { get; }
        ICoroutineTreesAsset CoroutineTreesAsset { get; set; }
        IHero TargetHero { get; set; }
        IHero CasterHero { get; set; }
        IReduceStatusEffectCounters ReduceStatusEffectCounters { get; }
        ISetStatusEffectCounters SetStatusEffectCounters { get; }
        IStatusEffectUpdateTiming StatusEffectUpdateTiming { get; set; }
        IStatusEffectInstance StatusEffectInstance { get; set; }
        IRemoveStatusEffect RemoveStatusEffect { get; }
        GameObject StatusEffectPreview { get; set; }
        IIncreaseStatusEffectCounters IncreaseStatusEffectCounters { get; }
        IDecreaseStatusEffectCounters DecreaseStatusEffectCounters { get; }
    }
}