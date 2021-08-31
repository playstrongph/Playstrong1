using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace ScriptableObjects.Enums.AttackTargetType
{
    public class AttackTargetTypeAsset : ScriptableObject, IAttackTargetTypeAsset
    {

        public virtual IEnumerator DealAttackDamage(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

           //SingleTargetAttack
            //dealDamage.DealSingleAttackDamage(thisHero, targetHero, attackPower, criticalFactor);
            
            //MultipleTargetAttack
           //dealDamage.DealMultipleAttackDamage(thisHero, targetHero, attackPower, criticalFactor);

            logicTree.EndSequence();
            yield return null;
        }



    }
}
