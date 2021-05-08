using UnityEngine;

namespace Logic
{
   public class PanelHeroSkills : MonoBehaviour, IPanelHeroSkills
   {
        [SerializeField] private GameObject _panelSkills;

        public GameObject PanelSkills
        {
            get { return  _panelSkills;}
            set { _panelSkills = value; }
        }

        public void ShowPanelSkills()
        {
            PanelSkills.SetActive(true);
        }
        
        public void HidePanelSkills()
        {
            PanelSkills.SetActive(true);
        }

   }
}
