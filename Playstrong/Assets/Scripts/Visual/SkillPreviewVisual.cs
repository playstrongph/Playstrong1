using System;
using Interfaces;
using References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class SkillPreviewVisual : MonoBehaviour, ISkillPreviewVisual
    {

        [SerializeField] [RequireInterface(typeof(ISkill))]
        private Object _skill;
        public ISkill Skill => _skill as ISkill;

        [SerializeField] private Canvas _previewCanvas;
        public Canvas PreviewCanvas => _previewCanvas;
        
        [SerializeField] private Image _previewImage;
        public Image PreviewImage => _previewImage;

        [SerializeField] private TextMeshProUGUI _cooldown;
        public TextMeshProUGUI Cooldown => _cooldown;
        
        [SerializeField] private TextMeshProUGUI _previewName;
        public TextMeshProUGUI PreviewName => _previewName;
        
        [SerializeField] private TextMeshProUGUI _description;
        public TextMeshProUGUI Description => _description;

        private ILoadSkillPreviewVisuals _loadSkillPreviewVisuals;
        public ILoadSkillPreviewVisuals LoadSkillPreviewVisuals => _loadSkillPreviewVisuals;

        private Transform _previewTransform;

        public Transform PreviewTransform
        {
            get { return _previewTransform; }
            set { _previewTransform = value; }
        }

        private void Awake()
        {
            _loadSkillPreviewVisuals = GetComponent<ILoadSkillPreviewVisuals>();
            _previewTransform = this.transform;
        }
    }
}
