using System.Collections.Generic;

namespace ScriptableObjects.SkillCondition
{
    public interface ISkillEffectAsset
    {
        void UseSkill();

        List<ISkillConditionAsset> SkillActionAssets { get; }
    }
}