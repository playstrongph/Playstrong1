using References;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    public interface ISkillDisplayTypeAsset
    {

        void HideSkillAndTargetVisual(ISkill skill);

        void ShowSkillAndTargetVisual(ISkill skill);

    }
}