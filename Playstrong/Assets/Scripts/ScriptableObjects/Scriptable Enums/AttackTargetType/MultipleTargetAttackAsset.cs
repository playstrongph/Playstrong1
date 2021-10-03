using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace ScriptableObjects.Enums.AttackTargetType
{
    [CreateAssetMenu(fileName = "MultipleTargetAttack", menuName = "SO's/Scriptable Enums/Attack Target Type/MultipleTargetAttack")]
    public class MultipleTargetAttackAsset : SingleOrMultiAttackTypeAsset
    {
        //TODO: Disable during testing
        public override IEnumerator DealAttackDamageTest(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(PreMultiAttackEvents(thisHero,targetHero));

            logicTree.AddCurrent(dealDamage.DealMultipleAttackDamage(thisHero, targetHero, attackPower, criticalFactor));
            
            logicTree.AddCurrent(PostMultiAttackEvents(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        //DEAL DAMAGE TEST
        public override IEnumerator DealAttackDamageTest(IDealDamageTest dealDamageTest, IHero thisHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(PreMultiAttackEvents(thisHero,targetHero));

            logicTree.AddCurrent(dealDamageTest.DealMultiAttackDamage(thisHero, targetHero, nonCriticalDamage, criticalDamage));
            
            logicTree.AddCurrent(PostMultiAttackEvents(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;
        }
        
       
       



    }
}
