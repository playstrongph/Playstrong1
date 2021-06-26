using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class HeroPreviewAttack : MonoBehaviour, IHeroPreviewAttack
    {
        [SerializeField] 
        private TextMeshProUGUI _text;


        public void SetHeroPreviewAttackText(string previewAttack)
        {
            _text.text = previewAttack;
        }

        public void SetHeroPreviewAttackColor(Color color)
        {
            _text.color = color;
        }
    }
}
