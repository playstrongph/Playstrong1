using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class HeroPreviewHealth : MonoBehaviour, IHeroPreviewHealth
    {
        [SerializeField] 
        private TextMeshProUGUI _text;


        public void SetHeroPreviewHealth(string previewHealth)
        {
            _text.text = previewHealth;
        }
    }
}
