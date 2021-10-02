using ScriptableObjects.Enums.SkillStatus;

namespace Logic
{
    public interface IUpdateSkillReadiness
    {
        void SetStatus(int cooldown);

        ISkillReadiness SkillReady { get; }
        ISkillReadiness SkillNotReady { get; }
    }
}