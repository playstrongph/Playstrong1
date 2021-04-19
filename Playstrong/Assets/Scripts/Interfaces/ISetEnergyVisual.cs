using UnityEngine;

namespace Interfaces
{
    public interface ISetEnergyVisual
    {
        void SetEnergyTextAndBarFill(int energyValue);
        void SetEnergyTextColor(Color textColor);
        void SetBarFillColor(Color energyBarColor);
    }
}