using ScriptableObjects.Enums.SkillStatus;

namespace Logic
{
    public interface IUpdateSkillReadiness
    {
        void SetStatusBasedOnSkillCooldown(int cooldown);

        ISkillReadiness SkillReady { get; }
        ISkillReadiness SkillNotReady { get; }
    }
}