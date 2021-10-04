using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "SkillAttackActionAsset", menuName = "SO's/SkillActions/SkillAttackActionAsset")]
    
    public class SkillAttackActionAsset : SkillActionAsset
    {
        [Header("Attack Actions")] [SerializeField]
        private ScriptableObject _normalSkillAttack;
        private IHeroAction NormalSkillAttack => _normalSkillAttack as IHeroAction;
        [SerializeField]
        private ScriptableObject _critricalSkillAttack;
        private IHeroAction CriticalSkillAttack => _critricalSkillAttack as IHeroAction;


        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //Pre-AttackEvents
            logicTree.AddCurrent(PreAttackEvents(thisHero,targetHero));
            logicTree.AddCurrent(PreSkillAttackEvents(thisHero,targetHero));
           
            
            //StartAttackActions
            logicTree.AddCurrent(SetNormalOrCriticalAttack(thisHero,targetHero));
            
            
            //Post-AttackEvents
            logicTree.AddCurrent(PostSkillAttackEvents(thisHero,targetHero));
            logicTree.AddCurrent(PostAttackEvents(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator SetNormalOrCriticalAttack(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var criticalChance = thisHero.HeroLogic.OtherAttributes.CriticalStrikeChance;
            var criticalResistance = thisHero.HeroLogic.OtherAttributes.CriticalStrikeResistance;
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(0f, 100f);
            
            netChance = Mathf.Clamp(netChance, 0f, 100f);

            logicTree.AddCurrent(randomChance <= netChance
                ? CriticalSkillAttack.StartAction(thisHero, targetHero)
                : NormalSkillAttack.StartAction(thisHero, targetHero));

            logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator PreSkillAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeSkillAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PreSkillAttack(thisHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PreAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PreAttack(thisHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PostSkillAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterSkillAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PostSkillAttack(thisHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PostAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PostAttack(thisHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        

       



      


    }
}
