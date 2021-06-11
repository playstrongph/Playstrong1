using System.Collections.Generic;

namespace ScriptableObjects.SkillCondition
{
    public interface ISkillEffectAsset
    {
        void UseSkill();

        List<ISkillConditionAsset> SkillConditionAssets { get; }
    }
}