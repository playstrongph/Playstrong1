using Interfaces;
using UnityEngine.UI;

namespace Visual
{
    public interface IPortrait
    {
        Image HeroPortraitImage { get; }

        void SetPortraitImage(IHeroAsset heroAsset);
    }
}