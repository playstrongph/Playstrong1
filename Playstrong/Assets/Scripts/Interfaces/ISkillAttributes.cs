using References;
using ScriptableObjects.Enums;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using ScriptableObjects.ScriptableEnumScripts.SkillCooldownType;
using ScriptableObjects.SkillEffects;

namespace Interfaces
{
    public interface ISkillAttributes
    {
        int Cooldown { get; set; }
        int BaseCooldown { get; set; }

        ISkillType SkillType { get; set; }

        ISkillEnabledStatus SkillEnabledStatus { get; set; }

        ISkillTarget SkillTarget { get; set; }

        ISkillReadiness SkillReadiness { get; set; }

        ISkillUseStatusAsset SkillUseStatus { get; set; }

        ISkillEffectAsset SkillEffectAsset { get; set; }
        
        ISkill SkillReference { get; }

        ISkillCooldownTypeAsset SkillCooldownType { get; set; }

        ISkillDisplayTypeAsset SkillDisplayType { get; set; }
    }
}