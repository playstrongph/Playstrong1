using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class HeroPreviewSpeed : MonoBehaviour, IHeroPreviewSpeed
    {
        [SerializeField] 
        private TextMeshProUGUI _text;


        public void SetHeroPreviewSpeedText(string previewSpeed)
        {
            _text.text = previewSpeed;
        }
        
        public void SetHeroPreviewSpeedColor(Color color)
        {
            _text.color = color;
        }
    }
}
