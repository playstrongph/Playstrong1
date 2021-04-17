using UnityEngine;

namespace Assets.Scripts.Visual.Interfaces
{
    public interface ISetAttackVisual
    {
        void SetAttackText(string attackValue);
        void SetAttackTextColor(Color textColor);
    }
}