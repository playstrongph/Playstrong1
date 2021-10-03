using References;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    public interface ISkillEnabledStatus
    {
        void DisableActiveSkill(ISkill skill);
        void EnableActiveSkill(ISkill skill);
        void DisablePassiveSkill(ISkill skill);
        void EnablePassiveSkill(ISkill skill);


    }
}