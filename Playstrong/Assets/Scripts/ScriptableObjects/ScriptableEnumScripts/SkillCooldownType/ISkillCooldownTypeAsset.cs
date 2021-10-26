using System.Collections;
using References;

namespace ScriptableObjects.ScriptableEnumScripts.SkillCooldownType
{
    public interface ISkillCooldownTypeAsset
    {
        IEnumerator TurnReduceCooldown(ISkill skill, int counter);
        IEnumerator IncreaseCooldown(ISkill skill, int counter);
        IEnumerator SetSkillCdToValue(ISkill skill, int counter);
        IEnumerator TurnResetCooldownToMax(ISkill skill);
        IEnumerator RefreshCooldownToZero(ISkill skill);
    }
}