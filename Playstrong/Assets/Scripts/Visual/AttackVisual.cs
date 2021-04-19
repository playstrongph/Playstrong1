using Interfaces;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class AttackVisual : MonoBehaviour, ISetAttackVisual
    {
       
        [SerializeField]
        private TextMeshProUGUI text;

        

        public void SetAttackText(string attackValue)
        {
            text.text = attackValue;
        }

        public void SetAttackTextColor(Color textColor)
        {
            text.color = textColor;
        }








    }
}
