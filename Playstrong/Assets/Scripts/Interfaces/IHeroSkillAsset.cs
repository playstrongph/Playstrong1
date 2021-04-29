using UnityEngine;

namespace Interfaces
{
    public interface IHeroSkillAsset
    {
        string Name { get; }
        
        string Description { get; }
        
        Sprite SkillIcon { get; }
        
        int Cooldown { get; }
        
    }
}