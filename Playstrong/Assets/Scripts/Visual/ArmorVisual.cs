using System;
using System.Collections.Generic;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class ArmorVisual : MonoBehaviour, ISetArmorVisual
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private TextMeshProUGUI text;

        private List<Action> _displayArmor = new List<Action>();

        public void SetArmorText(int value)
        {
            var armorValue = value.ToString();
            var index = Mathf.Clamp(value, 0, 1);
            
            text.text = armorValue;
            _displayArmor[index]();
        }

        private void SetArmorTextColor(Color textColor)
        {
            text.color = textColor;
        }
        
        private void Awake()
        {
            _displayArmor.Add(HideArmorIcon);
            _displayArmor.Add(ShowArmorIcon);
        }

        private void HideArmorIcon()
        {   
            icon.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
        }
        
        private void ShowArmorIcon()
        {   
            icon.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
        }

       
    }
}
