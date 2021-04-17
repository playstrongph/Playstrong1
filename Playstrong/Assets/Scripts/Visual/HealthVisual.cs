using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
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
