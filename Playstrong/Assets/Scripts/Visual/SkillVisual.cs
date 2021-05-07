using System;
using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class SkillVisual : MonoBehaviour, ISkillVisual
    {
        [SerializeField] [RequireInterface(typeof(ISkillPrefab))]
        private Object _skillPrefab;

        public ISkillPrefab SkillPrefab => _skillPrefab as ISkillPrefab;

        [SerializeField] private Canvas _skillCanvas;
        public Canvas SkillCanvas => _skillCanvas;

        [SerializeField] private GameObject _skillGlow;
        public GameObject SkillGlow => _skillGlow;

        [SerializeField] private Image _skillGraphic;
        public Image SkillGraphic => _skillGraphic;

        [SerializeField] private TextMeshProUGUI _cooldownText;
        public TextMeshProUGUI CooldownText => _cooldownText;

        private ILoadSkillVisuals _loadSkillVisuals;
        public ILoadSkillVisuals LoadSkillVisuals => _loadSkillVisuals;

        private void Awake()
        {
            _loadSkillVisuals = GetComponent<ILoadSkillVisuals>();
        }
    }
}
