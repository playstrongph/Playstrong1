using Interfaces;
using UnityEngine.UI;

namespace Visual
{
    public interface IHeroPortrait
    {
        Image HeroPortraitImage { get; }

        void SetPortraitImage(IHeroAsset heroAsset);
    }
}