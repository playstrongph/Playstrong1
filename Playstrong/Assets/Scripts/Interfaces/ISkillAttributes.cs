using References;
using ScriptableObjects.Enums;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
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

        ISkillEffectAsset SkillEffect { get; set; }
        
        ISkill SkillReference { get; set; }
    }
}