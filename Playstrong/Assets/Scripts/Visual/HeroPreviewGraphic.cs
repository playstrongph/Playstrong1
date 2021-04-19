using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class HeroPreviewGraphic : MonoBehaviour, IHeroPreviewGraphic
    {
        [SerializeField] private Image _image;


        public void SetHeroPreviewGraphic(Sprite graphicImage)
        {
            _image.sprite = graphicImage;
        }
    }
}
