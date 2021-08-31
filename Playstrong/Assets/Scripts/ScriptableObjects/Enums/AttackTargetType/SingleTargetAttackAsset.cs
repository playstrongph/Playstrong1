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
           
            //Note: this is called
            Debug.Log("Single Target Attack Deal AttackDamage");
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

           //SingleTargetAttack
            logicTree.AddCurrent(dealDamage.DealSingleAttackDamage(thisHero, targetHero, attackPower, criticalFactor));
            
            //MultipleTargetAttack
           //dealDamage.DealMultipleAttackDamage(thisHero, targetHero, attackPower, criticalFactor);

            logicTree.EndSequence();
            yield return null;
        }



    }
}
