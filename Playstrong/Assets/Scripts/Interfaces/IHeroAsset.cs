using UnityEngine;

namespace Interfaces
{
    public interface IHeroAsset
    {
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