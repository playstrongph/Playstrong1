using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class HealthVisual : MonoBehaviour
    {
        [SerializeField]
        private Image icon;
        public Sprite IconSprite
        {
            set => icon.sprite = value;
        }
        
        [SerializeField]
        private TextMeshProUGUI text;

        public string TextString
        {
            set => text.text = value;
        }

        public Color TextColor
        {
            set => text.color = value;
        }


    }
}
