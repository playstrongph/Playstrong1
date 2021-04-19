using UnityEngine;

namespace Interfaces
{
    public interface ISetHealthVisual
    {
        void SetHealthText(string healthValue);
        void SetHealthTextColor(Color textColor);
    }
}