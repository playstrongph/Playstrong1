using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class EnergyVisual : MonoBehaviour
    {
        [SerializeField]
        private Image barFill;
        public float BarFillAmount
        {
            //specified in Energy points
            set => barFill.fillAmount = value / 100;
        }

        public Color BarfillColor
        {
            set => barFill.color = value;
        }
 
        [SerializeField]
        private TextMeshProUGUI text;
        public string TextString
        {
            set => text.text = value +"%";
        }

        public Color TextColor
        {
            set => text.color = value;
        }


    }
}
