using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class StatusEffectPreview : MonoBehaviour, IStatusEffectPreview
    {
        [SerializeField]
        private Image _statusEffectIcon;

        public Image StatusEffectIcon => _statusEffectIcon;

        [SerializeField] private TextMeshProUGUI _statusEffectName;
        public TextMeshProUGUI StatusEffectName => _statusEffectName;

        [SerializeField] private TextMeshProUGUI _statusEffectDescription;
        public TextMeshProUGUI StatusEffectDescription => _statusEffectDescription;

        private ILoadStatusEffectPreview _loadStatusEffectPreview;
        public ILoadStatusEffectPreview LoadStatusEffectPreview => _loadStatusEffectPreview;

        private void Awake()
        {
            _loadStatusEffectPreview = GetComponent<ILoadStatusEffectPreview>();
        }
    }
}
