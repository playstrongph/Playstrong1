using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace ScriptableObjects.Enums.AttackTargetType
{
    [CreateAssetMenu(fileName = "SingleTargetAttack", menuName = "SO's/Scriptable Enums/Attack Target Type/SingleTargetAttack")]
    public class SingleTargetAttackAsset : AttackTargetTypeAsset
    {

        public override IEnumerator DealAttackDamage(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(dealDamage.DealSingleAttackDamage(thisHero, targetHero, attackPower, criticalFactor));
            
            logicTree.EndSequence();
            yield return null;
        }



    }
}
