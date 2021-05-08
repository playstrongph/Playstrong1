using UnityEngine;
using Visual;

namespace Logic
{
   
    public class PanelHeroPortrait : MonoBehaviour, IPanelHeroPortrait
    {
        [SerializeField] private GameObject _portrait;

        public GameObject Portrait
        {
            get { return  _portrait;}
            set { _portrait = value; }
        }

        public void ShowPanelPortrait()
        {
            Portrait.SetActive(true);
        }
        
        public void HidePanelPortrait()
        {
            Portrait.SetActive(true);
        }
    }
}
