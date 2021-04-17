using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
{
    public class EnergyVisual : MonoBehaviour
    {
        public Image _barFill;
        public TextMeshProUGUI _text;

        public float BarFillAmount
        {
            
            //specified in Energy points
            set { _barFill.fillAmount = value / 100; }
        }

        public Color BarfillColor
        {
            set { _barFill.color = value; }
        }

        public string TextString
        {
            set { _text.text = value +"%"; }
        }

        public Color TextColor
        {
            set { _text.color = value; }
        }


    }
}
