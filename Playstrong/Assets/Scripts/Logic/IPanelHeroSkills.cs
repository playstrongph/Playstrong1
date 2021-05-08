using UnityEngine;

namespace Logic
{
    public interface IPanelHeroSkills
    {
        GameObject PanelSkills { get; set; }

        void ShowPanelSkills();

        void HidePanelSkills();
    }
}