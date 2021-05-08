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

        public void ShowPortraitImage()
        {
            var heroPortrait = Portrait.GetComponent<IPortrait>();
            var portraitImage = heroPortrait.HeroPortraitImage.enabled = true;
        }
        
        public void HidePortraitImage()
        {
            var heroPortrait = Portrait.GetComponent<IPortrait>();
            var portraitImage = heroPortrait.HeroPortraitImage.enabled = false;
        }
    }
}
