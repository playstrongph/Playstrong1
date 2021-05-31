using ScriptableObjects.Enums;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;

namespace Interfaces
{
    public interface ISkillAttributes
    {
        int Cooldown { get; set; }
        int BaseCooldown { get; set; }

        ISkillType SkillType { get; set; }

        ISkillTarget SkillTarget { get; set; }
    }
}