using References;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    public interface ISkillEnabledStatus
    {
        void DisableSkill(ISkill skill);
        void EnableSkill(ISkill skill);

        void SetSkillReady(ISkill skill);

        void SetSkillNotReady(ISkill skill);
    }
}