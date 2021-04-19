using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class HeroPreviewAttack : MonoBehaviour, IHeroPreviewAttack
    {
        [SerializeField] 
        private TextMeshProUGUI _text;


        public void SetHeroPreviewAttack(string previewAttack)
        {
            _text.text = previewAttack;
        }
    }
}
