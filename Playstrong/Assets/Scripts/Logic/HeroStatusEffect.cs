using System;
using Interfaces;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using ScriptableObjects.StatusEffects.Instance;
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
        public string Name { get; set; }
        
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

        [SerializeField] [RequireInterface(typeof(IStatusEffectUpdateTiming))]
        private ScriptableObject _statusEffectUpdateTiming;

        public IStatusEffectUpdateTiming StatusEffectUpdateTiming
        {
            get => _statusEffectUpdateTiming as IStatusEffectUpdateTiming;
            set => _statusEffectUpdateTiming = value as ScriptableObject;
        }

        [SerializeField] [RequireInterface(typeof(IStatusEffectInstance))]
        private ScriptableObject _statusEffectInstance;

        public IStatusEffectInstance StatusEffectInstance
        {
            get => _statusEffectInstance as IStatusEffectInstance;
            set => _statusEffectInstance = value as ScriptableObject;

        }

        [SerializeField] private ScriptableObject _statusEffectDispelStatus;

        public IStatusEffectDispelStatusAsset StatusEffectDispelStatus
        {
            get => _statusEffectDispelStatus as IStatusEffectDispelStatusAsset;
            set => _statusEffectDispelStatus = value as ScriptableObject;
        }

        [SerializeField] private ScriptableObject _statusEffectChangeCounters;

        public IStatusEffectChangeCountersAsset StatusEffectChangeCounters
        {
            get => _statusEffectChangeCounters as IStatusEffectChangeCountersAsset;
            set => _statusEffectChangeCounters = value as ScriptableObject;
        }


        [SerializeField] private GameObject _statusEffectPreview;

        public GameObject StatusEffectPreview
        {
            get => _statusEffectPreview;
            set => _statusEffectPreview = value;
        }

        /// <summary>
        /// Non-Inspector Variables
        /// </summary>
        private ILoadStatusEffectValues _loadStatusEffectValues;
        public ILoadStatusEffectValues LoadStatusEffectValues => _loadStatusEffectValues;
        public ICoroutineTreesAsset CoroutineTreesAsset { get; set; }

        public IHero StatusEffectTargetHero { get; set; }
        public IHero StatusEffectCasterHero { get; set; }

        private IReduceStatusEffectCounters _reduceStatusEffectCounters;
        public IReduceStatusEffectCounters ReduceStatusEffectCounters => _reduceStatusEffectCounters;

        private ISetStatusEffectCounters _setStatusEffectCounters;
        public ISetStatusEffectCounters SetStatusEffectCounters => _setStatusEffectCounters;

        private IRemoveStatusEffect _removeStatusEffect;
        public IRemoveStatusEffect RemoveStatusEffect => _removeStatusEffect;

        private IIncreaseStatusEffectCounters _increaseStatusEffectCounters;
        public IIncreaseStatusEffectCounters IncreaseStatusEffectCounters => _increaseStatusEffectCounters;

        private IDecreaseStatusEffectCounters _decreaseStatusEffectCounters;
        public IDecreaseStatusEffectCounters DecreaseStatusEffectCounters => _decreaseStatusEffectCounters;

       

        private void Awake()
        {
            _loadStatusEffectValues = GetComponent<ILoadStatusEffectValues>();
            _reduceStatusEffectCounters = GetComponent<IReduceStatusEffectCounters>();
            _setStatusEffectCounters = GetComponent<ISetStatusEffectCounters>();
            _removeStatusEffect = GetComponent<IRemoveStatusEffect>();
            _increaseStatusEffectCounters = GetComponent<IIncreaseStatusEffectCounters>();
            _decreaseStatusEffectCounters = GetComponent<IDecreaseStatusEffectCounters>();

        }
    }
}
