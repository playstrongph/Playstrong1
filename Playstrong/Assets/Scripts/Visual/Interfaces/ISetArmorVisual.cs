using UnityEngine;

namespace Assets.Scripts.Visual
{
    public interface ISetArmorVisual
    {
        void SetArmorText(string armorValue);
        void SetArmorTextColor(Color textColor);
        void HideArmorIcon();
        void ShowArmorIcon();
    }
}