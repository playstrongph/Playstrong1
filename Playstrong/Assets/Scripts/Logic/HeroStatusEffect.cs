using System;
using ScriptableObjects.StatusEffects;
using ScriptableObjects.StatusEffects.StatusEffectType;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Visual;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroStatusEffect : MonoBehaviour, IHeroStatusEffect
    {
        [SerializeField]
        private Object _statusEffectAsset;

        public IStatusEffect StatusEffectAsset
        {
            get => _statusEffectAsset as IStatusEffect;
            set => _statusEffectAsset = value as Object;
        }

        [SerializeField]
        private int _counters;
        public int Counters
        {
            get => _counters;
            set => _counters = value;
        }

        [SerializeField] private Object _statusEffectType;

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
