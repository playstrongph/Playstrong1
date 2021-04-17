using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
{
    public class ArmorVisual : MonoBehaviour, ISetArmorVisual
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private TextMeshProUGUI text;

        public void SetArmorText(string armorValue)
        {
            text.text = armorValue;
        }

        public void SetArmorTextColor(Color textColor)
        {
            text.color = textColor;
        }

        public void HideArmorIcon()
        {   
            icon.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
        }
        
        public void ShowArmorIcon()
        {   
            icon.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
        }







    }
}
