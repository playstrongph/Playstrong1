using TMPro;
using UnityEngine;

namespace Assets.Scripts.Visual
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
