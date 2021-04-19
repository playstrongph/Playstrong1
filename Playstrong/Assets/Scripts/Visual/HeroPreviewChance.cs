using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class HeroPreviewChance : MonoBehaviour, IHeroPreviewChance
    {
        [SerializeField] 
        private TextMeshProUGUI _text;


        public void SetHeroPreviewChance(string previewChance)
        {
            _text.text = previewChance+"%";
        }
    }
}
