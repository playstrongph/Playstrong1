using Interfaces;
using Logic;
using ScriptableObjects;
using ScriptableObjects.Others;
using ScriptableObjects.Scriptable_Enums.SkillEnabledStatus;
using Visual;

namespace References
{
    public interface ISkill
    {

        string SkillName { get; set; }
        ISkillLogic SkillLogic { get; }
        ISkillVisual SkillVisual { get; }
        ISkillPreviewVisual SkillPreviewVisual { get; }

        ITargetSkill TargetSkill { get; }

        IHero Hero { get; set; }

        ICoroutineTreesAsset CoroutineTreesAsset { get; }

        ISkill PanelSkill { get; set; }

        
    }
}