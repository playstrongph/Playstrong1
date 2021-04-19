using TMPro;
using UnityEngine;

namespace Assets.Scripts.Visual
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
