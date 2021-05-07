using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class HeroPortrait : MonoBehaviour, IHeroPortrait
    {
        [SerializeField] private Image _heroPortraitImage;
        public Image HeroPortraitImage => _heroPortraitImage;

        public void SetPortraitImage(IHeroAsset heroAsset)
        {
            HeroPortraitImage.sprite = heroAsset.HeroSprite;
        }

    }
}
