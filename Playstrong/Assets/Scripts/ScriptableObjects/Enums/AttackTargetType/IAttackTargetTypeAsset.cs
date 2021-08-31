using System.Collections;
using Interfaces;
using Logic;

namespace ScriptableObjects.Enums.SkillStatus
{
    public interface IAttackTargetTypeAsset
    {
        IEnumerator DealAttackDamage(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor);
    }
}