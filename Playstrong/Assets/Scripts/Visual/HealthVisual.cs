using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class HealthVisual : MonoBehaviour, ISetHealthVisual
    {
        
        [SerializeField]
        private TextMeshProUGUI text;

        public void SetHealthText(string healthValue)
        {
            text.text = healthValue;
        }

        public void SetHealthTextColor(Color textColor)
        {
            text.color = textColor;
        }


    }
}
