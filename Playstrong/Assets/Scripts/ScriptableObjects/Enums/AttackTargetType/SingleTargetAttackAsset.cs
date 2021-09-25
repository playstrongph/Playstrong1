using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace ScriptableObjects.Enums.AttackTargetType
{
    [CreateAssetMenu(fileName = "SingleTargetAttack", menuName = "SO's/Scriptable Enums/Attack Target Type/SingleTargetAttack")]
    public class SingleTargetAttackAsset : SingleOrMultiAttackTypeAsset
    {

        //TODO: Disable During testing
        public override IEnumerator DealAttackDamage(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(PreSingleAttackEvents(thisHero,targetHero));
            
            logicTree.AddCurrent(dealDamage.DealSingleAttackDamage(thisHero, targetHero, attackPower, criticalFactor));
            
            logicTree.AddCurrent(PostSingleAttackEvents(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        //DEAL DAMAGE TEST
        public override IEnumerator DealAttackDamage(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(PreSingleAttackEvents(thisHero,targetHero));

            logicTree.AddCurrent(dealDamage.DealMultipleAttackDamage(thisHero, targetHero, nonCriticalDamage, criticalDamage));
            
            logicTree.AddCurrent(PostSingleAttackEvents(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        
        //EVENTS
        private IEnumerator PreSingleAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeHeroDealsSingleAttack(thisHero);
            targetHero.HeroLogic.HeroEvents.BeforeHeroTakesSingleAttack(thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        private IEnumerator PostSingleAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterHeroDealsSingleAttack(thisHero);
            targetHero.HeroLogic.HeroEvents.AfterHeroTakesSingleAttack(thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
       



    }
}
