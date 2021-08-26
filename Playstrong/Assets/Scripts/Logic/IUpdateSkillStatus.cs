using ScriptableObjects.Enums.SkillStatus;

namespace Logic
{
    public interface IUpdateSkillStatus
    {
        void SetStatus(int cooldown);

        ISkillStatus SkillReady { get; }
        ISkillStatus SkillNotReady { get; }
    }
}