using UnityEngine;

namespace Visual
{
    public class HeroPortrait : MonoBehaviour, IHeroPortrait
    {
        [SerializeField] private GameObject _heroPortrait;

        public GameObject PortraitReference
        {
            get { return  _heroPortrait;}
            set { _heroPortrait = value; }
        }

        public void ShowPortraitImage()
        {
            var heroPortrait = PortraitReference.GetComponent<IHeroPortraitReferences>();
            var portraitImage = heroPortrait.HeroPortraitImage.enabled = true;
        }
        
        public void HidePortraitImage()
        {
            var heroPortrait = PortraitReference.GetComponent<IHeroPortraitReferences>();
            var portraitImage = heroPortrait.HeroPortraitImage.enabled = false;
        }
    }
}
