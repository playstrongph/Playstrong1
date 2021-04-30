using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class HeroPortraitReferences : MonoBehaviour, IHeroPortraitReferences
    {
        [SerializeField] private Image _heroPortraitImage;
        public Image HeroPortraitImage => _heroPortraitImage;

        public void SetPortraitImage(IHeroAsset heroAsset)
        {
            HeroPortraitImage.sprite = heroAsset.HeroSprite;
        }

    }
}
