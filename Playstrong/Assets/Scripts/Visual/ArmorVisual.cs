using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Visual
{
    public class ArmorVisual : MonoBehaviour
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
