using UnityEngine;

namespace Logic
{
    public interface IPanelHeroPortrait
    {
        GameObject Portrait { get; set; }

        void ShowPanelPortrait();
        
        void HidePanelPortrait();
    }
}