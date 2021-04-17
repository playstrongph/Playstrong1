using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
{
    public class EnergyVisual : MonoBehaviour, ISetEnergyVisual
    {
        [SerializeField]
        private Image barFill;
       
        [SerializeField]
        private TextMeshProUGUI text;
        
       
        public void SetEnergyTextAndBarFill(int energyValue)
        {
            text.text = energyValue.ToString() +"%";
            barFill.fillAmount = energyValue / 100;
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
