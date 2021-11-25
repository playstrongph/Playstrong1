using System.Collections.Generic;
using Logic;
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

        int FightingSpirit { get; }

        IRarityEnumAsset Rarity { get; }

        IHeroSkillAsset HeroSkills { get; }

        List<ScriptableObject> GetHeroSkills();

        ITargetStatus TargetStatus { get; }

        IFactionEnumAsset Faction { get; }


    }
}