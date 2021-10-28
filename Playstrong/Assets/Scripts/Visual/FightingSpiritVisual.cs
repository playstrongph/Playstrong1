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
        

        public void SetFightingSpiritText(int fightingSpiritValue)
        {
            var fightingSpiritValueString = fightingSpiritValue.ToString();
            text.text = fightingSpiritValueString;
            
            if (fightingSpiritValue >0)
                ShowFightingSpiritTextAndIcon();
            else
            {
               HideFightingSpiritTextAndIcon();
            }
            
            
            
        }

        public void HideFightingSpiritTextAndIcon()
        {
            //Debug.Log("HideFightingSpiritTextAndIcon");
            //text.enabled = false;
            //icon.enabled = false;
            
            text.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);

        }
        
        public void ShowFightingSpiritTextAndIcon()
        {
            //Debug.Log("ShowFightingSpiritTextAndIcon");
            //text.enabled = true;
            //icon.enabled = true;
            
            text.gameObject.SetActive(true);
            icon.gameObject.SetActive(true);

        }












    }
}
