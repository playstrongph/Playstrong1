using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class HeroPreviewName : MonoBehaviour, IHeroPreviewName
    {
        [SerializeField] 
        private TextMeshProUGUI _text;


        public void SetHeroPreviewName(string previewName)
        {
            _text.text = previewName;
        }
    }
}
