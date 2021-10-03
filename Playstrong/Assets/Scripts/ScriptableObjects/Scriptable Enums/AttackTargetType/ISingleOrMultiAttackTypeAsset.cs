using System.Collections;
using Interfaces;
using Logic;

namespace ScriptableObjects.Enums.SkillStatus
{
    public interface ISingleOrMultiAttackTypeAsset
    {
        IEnumerator DealAttackDamageTest(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor);

        IEnumerator DealAttackDamageTest(IDealDamageTest dealDamageTest, IHero thisHero, IHero targetHero,
            int nonCriticalDamage, int criticalDamage);
    }
}