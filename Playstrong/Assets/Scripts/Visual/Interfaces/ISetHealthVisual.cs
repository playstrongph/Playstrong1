using UnityEngine;

namespace Assets.Scripts.Visual
{
    public interface ISetHealthVisual
    {
        void SetHealthText(string healthValue);
        void SetHealthTextColor(Color textColor);
    }
}