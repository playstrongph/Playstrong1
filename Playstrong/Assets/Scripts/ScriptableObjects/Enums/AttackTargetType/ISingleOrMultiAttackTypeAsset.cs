using System.Collections;
using Interfaces;
using Logic;

namespace ScriptableObjects.Enums.SkillStatus
{
    public interface ISingleOrMultiAttackTypeAsset
    {
        IEnumerator DealAttackDamage(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor);
    }
}