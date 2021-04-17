using System;
using References;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Visual
{
    public class HeroPreviewVisual : MonoBehaviour
    {
        [SerializeField]
        private HeroObjectReferences heroObjectReferences;
        
        [SerializeField]
        private Canvas previewCanvas;

        public Canvas PreviewCanvas => previewCanvas;

        [SerializeField]
        private Image frameGraphic;

        public Sprite FrameGraphic
        {
            set => frameGraphic.sprite = value;
        }
        
        [SerializeField]
        private Image previewGraphic;

        public Sprite PreviewGraphic
        {
            set => previewGraphic.sprite = value;
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
