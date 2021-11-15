using ScriptableObjects.Enums;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using ScriptableObjects.ScriptableEnumScripts.SkillCooldownType;
using ScriptableObjects.SkillEffects;
using UnityEngine;

namespace Interfaces
{
    public interface IHeroSkillAsset
    {
        string SkillName { get; }
        
        string Description { get; }
        
        ISkillEffectAsset SkillEffect { get; }
        
        Sprite SkillIcon { get; }
        
        int BaseCooldown { get; }

        ISkillType SkillType { get; }

        ISkillTarget SkillTarget { get; }

        ISkillReadiness SkillReadiness { get; }

        ISkillCooldownTypeAsset SkillCooldownType { get; }

        ISkillDisplayTypeAsset SkillDisplayType { get; }


    }
}