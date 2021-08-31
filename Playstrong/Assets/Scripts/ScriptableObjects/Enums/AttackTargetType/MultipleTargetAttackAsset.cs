using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace ScriptableObjects.Enums.AttackTargetType
{
    [CreateAssetMenu(fileName = "MultipleTargetAttack", menuName = "SO's/Scriptable Enums/Attack Target Type/MultipleTargetAttack")]
    public class MultipleTargetAttackAsset : AttackTargetTypeAsset
    {

        public override IEnumerator DealAttackDamage(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

           //SingleTargetAttack
           //dealDamage.DealSingleAttackDamage(thisHero, targetHero, attackPower, criticalFactor);
            
           //MultipleTargetAttack
           logicTree.AddCurrent(dealDamage.DealMultipleAttackDamage(thisHero, targetHero, attackPower, criticalFactor));

            logicTree.EndSequence();
            yield return null;
        }



    }
}
