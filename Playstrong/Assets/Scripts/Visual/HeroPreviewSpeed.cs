using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class HeroPreviewSpeed : MonoBehaviour, IHeroPreviewSpeed
    {
        [SerializeField] 
        private TextMeshProUGUI _text;


        public void SetHeroPreviewSpeed(string previewSpeed)
        {
            _text.text = previewSpeed;
        }
    }
}
