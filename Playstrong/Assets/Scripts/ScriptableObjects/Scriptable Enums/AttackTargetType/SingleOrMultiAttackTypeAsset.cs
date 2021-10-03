using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace ScriptableObjects.Enums.AttackTargetType
{
    public class SingleOrMultiAttackTypeAsset : ScriptableObject, ISingleOrMultiAttackTypeAsset
    {

        public virtual IEnumerator DealAttackDamageTest(IDealDamage dealDamage, IHero thisHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

           //SingleTargetAttack
            //dealDamage.DealSingleAttackDamage(thisHero, targetHero, attackPower, criticalFactor);
            
            //MultipleTargetAttack
           //dealDamage.DealMultipleAttackDamage(thisHero, targetHero, attackPower, criticalFactor);

            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator DealAttackDamageTest(IDealDamageTest dealDamageTest, IHero thisHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;


            logicTree.EndSequence();
            yield return null;
        }
        
        //EVENTS
        protected IEnumerator PreMultiAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeHeroDealsMultiAttack(thisHero);
            targetHero.HeroLogic.HeroEvents.BeforeHeroTakesMultiAttack(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        } 
        protected IEnumerator PostMultiAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterHeroDealsMultiAttack(thisHero);
            targetHero.HeroLogic.HeroEvents.AfterHeroTakesMultiAttack(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        protected IEnumerator PreSingleAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeHeroDealsSingleAttack(thisHero);
            targetHero.HeroLogic.HeroEvents.BeforeHeroTakesSingleAttack(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        protected IEnumerator PostSingleAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterHeroDealsSingleAttack(thisHero);
            targetHero.HeroLogic.HeroEvents.AfterHeroTakesSingleAttack(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }




    }
}
