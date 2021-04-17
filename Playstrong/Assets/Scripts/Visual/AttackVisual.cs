using Assets.Scripts.Visual.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
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
