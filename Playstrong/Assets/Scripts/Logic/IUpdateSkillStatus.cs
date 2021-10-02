using ScriptableObjects.Enums.SkillStatus;

namespace Logic
{
    public interface IUpdateSkillStatus
    {
        void SetStatus(int cooldown);

        ISkillReadiness SkillReady { get; }
        ISkillReadiness SkillNotReady { get; }
    }
}