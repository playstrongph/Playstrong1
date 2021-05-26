using ScriptableObjects.Enums;

namespace Interfaces
{
    public interface ISkillAttributes
    {
        int Cooldown { get; set; }
        int BaseCooldown { get; set; }

        ISkillType SkillType { get; set; }
    }
}