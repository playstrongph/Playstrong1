using Interfaces;
using UnityEngine;

namespace Logic
{
    public interface ILoadHeroAttributes
    {
        void LoadHeroAttributesFromHeroAsset(IHeroAsset heroAsset);
    }
}