using TMPro;
using UnityEngine;

namespace Assets.Scripts.Visual
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
