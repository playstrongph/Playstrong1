using UnityEngine;

namespace Visual
{
    public class HeroPortrait : MonoBehaviour, IHeroPortrait
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
