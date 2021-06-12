using ScriptableObjects.Enums;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;
using ScriptableObjects.SkillEffects;
using UnityEngine;

namespace Interfaces
{
    public interface IHeroSkillAsset
    {
        string Name { get; }
        
        string Description { get; }
        
        ISkillEffectAsset SkillEffect { get; }
        
        Sprite SkillIcon { get; }
        
        int Cooldown { get; }

        ISkillType SkillType { get; }

        ISkillTarget SkillTarget { get; }

        ISkillStatus SkillStatus { get; }

    }
}