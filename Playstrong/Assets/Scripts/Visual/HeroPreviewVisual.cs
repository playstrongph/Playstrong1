using System;
using Assets.Scripts.References;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
{
    public class HeroPreviewVisual : MonoBehaviour
    {
        [SerializeField]
        private HeroObjectReferences _heroObjectReferences;
        
        [SerializeField]
        private Canvas _previewCanvas;

        public Canvas PreviewCanvas
        {
            get { return _previewCanvas; }
        }
        
        [SerializeField]
        private Image _frameGraphic;

        public Sprite FrameGraphic
        {
            set { _frameGraphic.sprite = value; }
        }
        
        [SerializeField]
        private Image _previewGraphic;

        public Sprite PreviewGraphic
        {
            set { _previewGraphic.sprite = value; }
        }
        
        [SerializeField]
        private TextMeshProUGUI _previewNameText;

        public String PreviewNameText
        {
            set { _previewNameText.text = value; }
        }
        
        [SerializeField]
        private TextMeshProUGUI _previewAttackText;
        public String PreviewAttackText
        {
            set { _previewAttackText.text = value; }
        }
        
        [SerializeField]
        private TextMeshProUGUI _previewHealthText;
        public String PreviewHealthText
        {
            set { _previewHealthText.text = value; }
        }
        
        [SerializeField]
        private TextMeshProUGUI _previewSpeedText;
        public String PreviewSpeedText
        {
            set { _previewSpeedText.text = value; }
        }
        
        [SerializeField]
        private TextMeshProUGUI _previewChanceText;
        public String PreviewChanceText
        {
            set { _previewChanceText.text = value; }
        }
        
        
        
        
        
    }
}
