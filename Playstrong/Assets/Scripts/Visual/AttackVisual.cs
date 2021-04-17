using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
{
    public class AttackVisual : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;
        public Sprite IconSprite
        {
            set { _icon.sprite = value; }
        }
        
        [SerializeField]
        private TextMeshProUGUI _text;

        public string TextString
        {
            set { _text.text = value; }
        }

        public Color TextColor
        {
            set { _text.color = value; }
        }

        






    }
}
