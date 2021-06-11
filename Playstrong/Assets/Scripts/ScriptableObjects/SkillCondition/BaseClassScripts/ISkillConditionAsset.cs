using System.Collections.Generic;
using ScriptableObjects.SkillActions;

namespace ScriptableObjects.SkillCondition
{
    public interface ISkillConditionAsset
    {
        void Target();

        List<ISkillActionAsset> SkillActionAssets { get; }
    }
}