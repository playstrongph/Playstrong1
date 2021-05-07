using Interfaces;
using UnityEngine.UI;

namespace Visual
{
    public interface IHeroPortraitReferences
    {
        Image HeroPortraitImage { get; }

        void SetPortraitImage(IHeroAsset heroAsset);
    }
}