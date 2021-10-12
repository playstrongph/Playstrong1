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
    public interface IHeroStatusEffect
    {

        string Name { get; set; }
        IStatusEffectAsset StatusEffectAsset { get; set; }
        int Counters { get; set; }
        Image Icon { get; }
        TextMeshProUGUI CounterVisual { get; }

        IStatusEffectType StatusEffectType { get; set; }

        ILoadStatusEffectValues LoadStatusEffectValues { get; }
        
        ICoroutineTreesAsset CoroutineTreesAsset { get; set; }
        
        IHero StatusEffectTargetHero { get; set; }
        
        IHero StatusEffectCasterHero { get; set; }

        IReduceStatusEffectCounters ReduceStatusEffectCounters { get; }

        ISetStatusEffectCounters SetStatusEffectCounters { get; }

        IStatusEffectCounterUpdate StatusEffectCounterUpdate { get; set; }

        IStatusEffectInstance StatusEffectInstance { get; set; }

        IRemoveStatusEffect RemoveStatusEffect {get;}

        GameObject StatusEffectPreview {get; set;}

        IIncreaseStatusEffectCounters IncreaseStatusEffectCounters {get;}
        IDecreaseStatusEffectCounters DecreaseStatusEffectCounters {get;}
        
        //IStatusEffectComponent StatusEffectComponent {get;}
        
      


    }
}