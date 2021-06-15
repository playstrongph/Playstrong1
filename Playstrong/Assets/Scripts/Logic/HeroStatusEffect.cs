using System;
using ScriptableObjects.StatusEffects;
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
        [RequireInterface(typeof(IStatusEffectAsset))]
        private ScriptableObject _statusEffectAsset;

        public IStatusEffectAsset StatusEffectAsset
        {
            get => _statusEffectAsset as IStatusEffectAsset;
            set => _statusEffectAsset = value as ScriptableObject;
        }

        [SerializeField]
        private int _counters;
        public int Counters
        {
            get => _counters;
            set => _counters = value;
        }

        [SerializeField]
        [RequireInterface(typeof(IStatusEffectType))]
        private ScriptableObject _statusEffectType;

        public IStatusEffectType StatusEffectType
        {
            get => _statusEffectType as IStatusEffectType;
            set => _statusEffectType = value as ScriptableObject;
        }

        [SerializeField] private Image _icon;
        public Image Icon => _icon;
        
        [SerializeField] private TextMeshProUGUI _counterVisual;
        public TextMeshProUGUI CounterVisual => _counterVisual;

        private ILoadStatusEffectValues _loadStatusEffectValues;
        public ILoadStatusEffectValues LoadStatusEffectValues => _loadStatusEffectValues;

        private void Awake()
        {
            _loadStatusEffectValues = GetComponent<ILoadStatusEffectValues>();
        }
    }
}
