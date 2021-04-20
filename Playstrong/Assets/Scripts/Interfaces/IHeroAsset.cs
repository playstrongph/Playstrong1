using UnityEngine;

namespace Interfaces
{
    public interface IHeroAsset
    {
        /// <summary>
        /// Expose Properties for external access
        /// </summary>
        
        string Name { get; }

        string Description { get; }
        
        Sprite HeroSprite { get; }
        
        int Health { get; }
        
        int Attack { get; }
        
        int Speed { get; }
        
        int Chance { get; }
        
        int Armor { get; }

        IRarityEnumAsset Rarity { get; }
        
        







    }
}