using UnityEngine;

namespace Interfaces
{
    public interface ISetArmorVisual
    {
        void SetArmorText(string armorValue);
        void SetArmorTextColor(Color textColor);
        void HideArmorIcon();
        void ShowArmorIcon();
    }
}