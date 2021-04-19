using TMPro;
using UnityEngine;

namespace Assets.Scripts.Visual
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
