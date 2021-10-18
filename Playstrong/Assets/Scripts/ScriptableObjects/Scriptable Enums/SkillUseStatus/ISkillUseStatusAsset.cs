using References;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    public interface ISkillUseStatusAsset
    {
        int UsingSkill(ISkill skill);
        int NotUsingSkill(ISkill skill);
    }
}