using System.Collections;
using References;

namespace ScriptableObjects.ScriptableEnumScripts.SkillCooldownType
{
    public interface ISkillCooldownTypeAsset
    {
        IEnumerator ReduceCooldown(ISkill skill, int counter);
        IEnumerator IncreaseCooldown(ISkill skill, int counter);
        IEnumerator SetSkillCdToValue(ISkill skill, int counter);
        IEnumerator ResetCooldownToMax(ISkill skill);
        IEnumerator RefreshCooldownToZero(ISkill skill);
    }
}