using System;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using ScriptableObjects.StatusEffects.StatusEffectCounter;
using ScriptableObjects.StatusEffects.StatusEffectType;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Visual;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroStatusEffect : MonoBehaviour, IHeroStatusEffect
    {
        

        [SerializeField]
        private int _counters;
        public int Counters
        {
            get => _counters;
            set => _counters = value;
        }

       

        [SerializeField] private Image _icon;
        public Image Icon => _icon;
        
        [SerializeField] private TextMeshProUGUI _counterVisual;
        public TextMeshProUGUI CounterVisual => _counterVisual;

       

        [Header("Set In Script")]
        [SerializeField]
        [RequireInterface(typeof(IStatusEffectAsset))]
        private ScriptableObject _statusEffectAsset;

        public IStatusEffectAsset StatusEffectAsset
        {
            get => _statusEffectAsset as IStatusEffectAsset;
            set => _statusEffectAsset = value as ScriptableObject;
        }
        
        [SerializeField]
        [RequireInterface(typeof(IStatusEffectType))]
        private ScriptableObject _statusEffectType;

        public IStatusEffectType StatusEffectType
        {
            get => _statusEffectType as IStatusEffectType;
            set => _statusEffectType = value as ScriptableObject;
        }

        [SerializeField] [RequireInterface(typeof(IStatusEffectCounterUpdate))]
        private ScriptableObject _statusEffectCounterUpdate;

        public IStatusEffectCounterUpdate StatusEffectCounterUpdate
        {
            get => _statusEffectCounterUpdate as IStatusEffectCounterUpdate;
            set => _statusEffectCounterUpdate = value as ScriptableObject;
        }

        /// <summary>
        /// Non-Inspector Variables
        /// </summary>
        private ILoadStatusEffectValues _loadStatusEffectValues;
        public ILoadStatusEffectValues LoadStatusEffectValues => _loadStatusEffectValues;
        public ICoroutineTreesAsset CoroutineTreesAsset { get; set; }

        private IReduceStatusEffectCounters _reduceStatusEffectCounters;
        public IReduceStatusEffectCounters ReduceStatusEffectCounters => _reduceStatusEffectCounters;
        
        

        private void Awake()
        {
            _loadStatusEffectValues = GetComponent<ILoadStatusEffectValues>();
            _reduceStatusEffectCounters = GetComponent<IReduceStatusEffectCounters>();
        }
    }
}
