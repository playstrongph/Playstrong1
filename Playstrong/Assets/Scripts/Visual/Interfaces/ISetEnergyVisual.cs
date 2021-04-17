using UnityEngine;

namespace Assets.Scripts.Visual
{
    public interface ISetEnergyVisual
    {
        void SetEnergyTextAndBarFill(int energyValue);
        void SetEnergyTextColor(Color textColor);
        void SetBarFillColor(Color energyBarColor);
    }
}