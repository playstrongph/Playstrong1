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
        private Object _statusEffectAsset;

        public IStatusEffectAsset StatusEffectAsset
        {
            get => _statusEffectAsset as IStatusEffectAsset;
            set => _statusEffectAsset = value as Object;
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
        private Object _statusEffectType;

        public IStatusEffectType StatusEffectType
        {
            get => _statusEffectAsset as IStatusEffectType;
            set => _statusEffectAsset = value as Object;
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
