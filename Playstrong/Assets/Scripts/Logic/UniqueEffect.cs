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
    public class UniqueEffect : MonoBehaviour
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
        [RequireInterface(typeof(IUniqueEffectAsset))]
        private ScriptableObject _uniqueEffectAsset;

        public IStatusEffectAsset UniqueEffectAsset
        {
            get => _uniqueEffectAsset as IStatusEffectAsset;
            set => _uniqueEffectAsset = value as ScriptableObject;
        }

        //TODO: UniqueEffectCounterUpdate
        [SerializeField] [RequireInterface(typeof(IStatusEffectCounterUpdate))]
        private ScriptableObject _statusEffectCounterUpdate;

        public IStatusEffectCounterUpdate StatusEffectCounterUpdate
        {
            get => _statusEffectCounterUpdate as IStatusEffectCounterUpdate;
            set => _statusEffectCounterUpdate = value as ScriptableObject;
        }   
        
        //TODO: UniqueEffectInstance
        [SerializeField] [RequireInterface(typeof(IStatusEffectInstance))]
        private ScriptableObject _statusEffectInstance;

        public IStatusEffectInstance StatusEffectInstance
        {
            get => _statusEffectInstance as IStatusEffectInstance;
            set => _statusEffectInstance = value as ScriptableObject;
        }
        
        
        [SerializeField] private GameObject _uniqueEffectPreview;

        public GameObject UniqueEffectPreview
        {
            get => _uniqueEffectPreview;
            set => _uniqueEffectPreview = value;
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

        /*private IStatusEffectComponent _statusEffectComponent;
        public IStatusEffectComponent StatusEffectComponent => _statusEffectComponent;*/

        private void Awake()
        {
            _loadStatusEffectValues = GetComponent<ILoadStatusEffectValues>();
            _reduceStatusEffectCounters = GetComponent<IReduceStatusEffectCounters>();
            _setStatusEffectCounters = GetComponent<ISetStatusEffectCounters>();
            _removeStatusEffect = GetComponent<IRemoveStatusEffect>();
            _increaseStatusEffectCounters = GetComponent<IIncreaseStatusEffectCounters>();
            _decreaseStatusEffectCounters = GetComponent<IDecreaseStatusEffectCounters>();
            
            //TEST
            //_statusEffectComponent = GetComponent<IStatusEffectComponent>();

            

        }
    }
}
