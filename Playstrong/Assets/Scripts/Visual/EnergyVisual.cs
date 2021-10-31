using System.Collections;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class EnergyVisual : MonoBehaviour, ISetEnergyVisual
    {
        [SerializeField]
        private Image barFill;
       
        [SerializeField]
        private TextMeshProUGUI text;
        
       
        public void SetEnergyTextAndBarFill(int energyValue)
        {
            //Clamps the displayed text to 100%
            var energyDisplayText = Mathf.Min(100, energyValue);
            
            text.text = energyDisplayText.ToString() +"%";
            
            barFill.fillAmount = energyDisplayText/100f;
        }
        public void SetEnergyTextColor(Color textColor)
        {
            text.color = textColor;
        }

        public void SetBarFillColor(Color energyBarColor)
        {
            barFill.color = energyBarColor;
        }

        

    }
}
