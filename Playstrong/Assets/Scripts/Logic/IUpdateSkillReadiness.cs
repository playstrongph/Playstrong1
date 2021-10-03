using ScriptableObjects.Enums.SkillStatus;

namespace Logic
{
    public interface IUpdateSkillReadiness
    {
        ISkillReadiness SkillReady { get; }
        ISkillReadiness SkillNotReady { get; }
        void SetSkillReady();
        void SetSkillNotReady();
    }
}