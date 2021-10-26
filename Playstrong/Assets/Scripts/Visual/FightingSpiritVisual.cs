using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class FightingSpiritVisual : MonoBehaviour, IFightingSpiritVisual
    {
       
        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField] private Image icon;
        

        public void SetFightingSpiritText(string attackValue)
        {
            text.text = attackValue;
        }

        public void HideFightingSpiritTextAndIcon()
        {
            text.enabled = false;
            icon.enabled = false;

        }
        
        public void ShowFightingSpiritTextAndIcon()
        {
            text.enabled = true;
            icon.enabled = true;

        }












    }
}
