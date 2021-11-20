using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    
    /// <summary>
    /// Basic action used by Skill 1 BasicAttackBasicAction
    /// Basic action used by Skill 2 and Skill 3 when doing skill Attacks
    /// </summary>
    [CreateAssetMenu(fileName = "CounterAttackBasicAction", menuName = "SO's/BasicActions/C/CounterAttackBasicAction")]
    public class CounterAttackBasicActionAsset : BasicActionAsset
    {
        [Header("CRITICAL STRIKE FACTORS")] 
        [SerializeField] private int defaultSkillCriticalChance;
        
        //[SerializeField] private int defaultSkillCriticalResistance;

        [Header("DAMAGE FACTORS")]
        //To be used after revision of DealDamage/TakeDamage
        [SerializeField] private int flatAdditionalDamage;
        //To be used after revision of DealDamage/TakeDamage
        [SerializeField] private ScriptableObject calculatedAdditionalDamage;
        private ICalculatedFactorValueAsset CalculatedAdditionalDamage => calculatedAdditionalDamage as ICalculatedFactorValueAsset;

        [Header("Game Animation Asset")]
        [SerializeField] private ScriptableObject attackAnimation;
        private IGameAnimations AttackAnimation => attackAnimation as IGameAnimations;

        [Header("Attack Target Type")] [SerializeField]
        private ScriptableObject singleOrMultiAttack;
        private ISingleOrMultiAttackTypeAsset SingleOrMultiAttack => singleOrMultiAttack as ISingleOrMultiAttackTypeAsset;
        
        [SerializeField]
        private float _visualDelay = 0.7f;

        private int _finalAttackValue;
        private int _antiCounterAttackResistance = 200;
        
        //TARGET ACTION    
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
           
            //From the event: "thisHero" is the original attacker, "targetHero" is the counter-attacker
            if (targetHero.HeroLogic.OtherAttributes.HeroInabilityChance <= 0)
            {
                //logicTree.AddCurrent(SetAntiCounterResistance(targetHero));
                //logicTree.AddCurrent(CounterAttackHero(targetHero,thisHero));
                //logicTree.AddCurrent(DecreaseCounterResistance(targetHero));
                
                logicTree.AddSibling(CounterAttackActions(thisHero,targetHero));
            }
            
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator CounterAttackActions(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SetAntiCounterResistance(targetHero));         
                
            logicTree.AddCurrent(CounterAttackHero(targetHero,thisHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator CounterAttackHero(IHero counterAttacker, IHero originalAttacker)
        {
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;

            var counterAttackChance = counterAttacker.HeroLogic.OtherAttributes.CounterAttackChance;
            var counterAttackResistance = originalAttacker.HeroLogic.OtherAttributes.CounterAttackResistance 
                                          + originalAttacker.HeroLogic.OtherAttributes.AntiCounterAttackResistance;
            
            var netCounterAttackChance = counterAttackChance - counterAttackResistance;
            netCounterAttackChance = Mathf.Clamp(netCounterAttackChance, 1, 101);
            var randomNumber = Random.Range(0, 100);
            
            //TEST - Increase this hero's counterAttackResistance
            //counterAttacker.HeroLogic.OtherAttributes.CounterAttackResistance += 500;
            //logicTree.AddCurrent(IncreaseCounterResistance(counterAttacker));

            if (randomNumber <= netCounterAttackChance)
            {
                //PRE-ATTACK PHASE
                logicTree.AddCurrent(BeforeCounterAttackEvents(counterAttacker,originalAttacker));
                logicTree.AddCurrent(PreSkillAttackEvents(counterAttacker,originalAttacker));
                logicTree.AddCurrent(PreAttackEvents(counterAttacker,originalAttacker));

                
                //TEST - 20 Nov 2021
                //logicTree.AddCurrent(AttackHero(counterAttacker,originalAttacker));
                logicTree.AddCurrent(BasicSkillAttackHero(counterAttacker,originalAttacker));
                
                

                //POST ATTACK PHASE
                logicTree.AddCurrent(PostAttackEvents(counterAttacker,originalAttacker));
                logicTree.AddCurrent(PostSkillAttackEvents(counterAttacker,originalAttacker));
                logicTree.AddCurrent(AfterCounterAttackEvents(counterAttacker,originalAttacker));
            }
            else
            {
               logicTree.AddCurrent(ReSetAntiCounterResistance(originalAttacker));
               //logicTree.AddCurrent(ReSetAntiCounterResistance(counterAttacker));
            }
            
            
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        //TEST - 20 Nov 2021
        private IEnumerator BasicSkillAttackHero(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //FindBasicSKill
            var basicSkill = GetBasicSkill(thisHero);

            var standardActions = basicSkill.SkillLogic.SkillAttributes.SkillEffectAsset.StandardActions;

            foreach (var standardAction in standardActions)
            {
                standardAction.StartAction(thisHero,targetHero);
            }

            logicTree.EndSequence();
            yield return null;
        }
        
        private ISkill GetBasicSkill(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            ISkill basicSkill = null;
            
            //FindBasicSKill
            var skillObjects = thisHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();

                if (skill.SkillLogic.SkillAttributes.SkillType.GetBasicSKill() != null)
                    basicSkill = skill;
            }
            
            return basicSkill;
        }
        
        
        
        



        private IEnumerator AttackHero(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
                
            logicTree.AddCurrent(SetNormalOrCriticalAttack(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator SetNormalOrCriticalAttack(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            var criticalChance = thisHero.HeroLogic.OtherAttributes.CriticalStrikeChance + defaultSkillCriticalChance;
            var criticalResistance = targetHero.HeroLogic.OtherAttributes.CriticalStrikeResistance;
            
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(0f, 100f);
            netChance = Mathf.Clamp(netChance, 0f, 100f);

            logicTree.AddCurrent(randomChance <= netChance
                ? CriticalAttack(thisHero, targetHero)
                : NormalAttack(thisHero, targetHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator NormalAttack(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Normal Attack: ");
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Obsolete.  Delete during refactoring, currently being used by DragHeroAttack(which shall be removed)
            var dealDamage = thisHero.HeroLogic.DealDamage;
            
            //Test - dealDamage should be thisHero not targetHero
            var dealDamageTest = thisHero.HeroLogic.DealDamageTest;
            
            //var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = 0;
            
            
            var nonCriticalAttackDamage =
                Mathf.CeilToInt(thisHero.HeroLogic.HeroAttributes.Attack + CalculatedAdditionalDamage.GetCalculatedValue() +flatAdditionalDamage);
            var criticalAttackDamage = Mathf.CeilToInt(criticalFactor * nonCriticalAttackDamage);

            //MAIN ATTACK PHASE
            
            //visuals
            logicTree.AddCurrent(AttackHeroAnimation(thisHero,targetHero));
            
            //Single/Multiple Target.  Rename to SingleOrMultiAttackType 
            //TODO:Disable this during test
            //logicTree.AddCurrent(SingleOrMultiAttack.DealAttackDamage(dealDamage,thisHero, targetHero, attackPower, criticalFactor));
            
            //TEST
            logicTree.AddCurrent(SingleOrMultiAttack.DealAttackDamageTest(dealDamageTest,thisHero, targetHero, nonCriticalAttackDamage, criticalAttackDamage));
            
            //visuals
            logicTree.AddCurrent(AttackInterval(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator CriticalAttack(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Critical Attack: ");
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Obsolete.  Delete during refactoring, currently being used by DragHeroAttack(which shall be removed)
            var dealDamage = thisHero.HeroLogic.DealDamage;
            
            //Test - dealDamage should be thisHero not targetHero
            var dealDamageTest = thisHero.HeroLogic.DealDamageTest;
            
            var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = thisHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier/100;
            
            //TEST
            var nonCriticalAttackDamage =
                Mathf.CeilToInt(thisHero.HeroLogic.HeroAttributes.Attack + CalculatedAdditionalDamage.GetCalculatedValue() +flatAdditionalDamage);
            var criticalAttackDamage = Mathf.CeilToInt(criticalFactor * nonCriticalAttackDamage);

            //TODO: To be used after DealDamage change
            //var nonCriticalDamage = attackPower + AdditionalAttackDamage;
            //var criticalDamage = Mathf.FloorToInt(criticalFactor*nonCriticalDamage);

            //PRE-ATTACK PHASE
            //logicTree.AddCurrent(PreSkillAttackEvents(thisHero,targetHero));
            //logicTree.AddCurrent(PreAttackEvents(thisHero,targetHero));
            logicTree.AddCurrent(PreCriticalStrikeEvents(thisHero,targetHero));

            //MAIN ATTACK PHASE
            
            //VISUALS
            logicTree.AddCurrent(AttackHeroAnimation(thisHero,targetHero));
            
            //DEAL DAMAGE CALL - FOR IMPROVEMENT
            //Single/Multiple Target TODO:Needs Improvement in Implementation
            //logicTree.AddCurrent(SingleOrMultiAttack.DealAttackDamage(dealDamage,thisHero, targetHero, attackPower, criticalFactor));
            
            logicTree.AddCurrent(SingleOrMultiAttack.DealAttackDamageTest(dealDamageTest,thisHero, targetHero, nonCriticalAttackDamage, criticalAttackDamage));
            
            //VISUALS
            logicTree.AddCurrent(AttackInterval(thisHero,targetHero));
            
            //POST ATTACK PHASE
            logicTree.AddCurrent(PostCriticalStrikeEvents(thisHero,targetHero));
            //logicTree.AddCurrent(PostAttackEvents(thisHero,targetHero));
            //logicTree.AddCurrent(PostSkillAttackEvents(thisHero,targetHero));
                
            logicTree.EndSequence();
            yield return null;
        }

        //VISUALS
        private IEnumerator AttackInterval(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
                
            //Inserts delay in seconds before calling visualTree.EndSequence()
            visualTree.AddCurrentWait(_visualDelay, visualTree);
                
            logicTree.EndSequence();
            yield return null;
        }
        private IEnumerator AttackHeroAnimation(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;

            visualTree.AddCurrent(AttackAnimation.StartAnimation(thisHero,targetHero));
                
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator SetAntiCounterResistance(IHero counterAttacker)
        {
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;

            //TEST
            counterAttacker.HeroLogic.OtherAttributes.AntiCounterAttackResistance = _antiCounterAttackResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator ReSetAntiCounterResistance(IHero counterAttacker)
        {
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;

            //TEST
            counterAttacker.HeroLogic.OtherAttributes.AntiCounterAttackResistance = 0;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator DecreaseCounterResistance(IHero counterAttacker)
        {
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;

            counterAttacker.HeroLogic.OtherAttributes.CounterAttackResistance -= _antiCounterAttackResistance;
            
            logicTree.EndSequence();
            yield return null;
        }




        //EVENTS
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
        private IEnumerator PreCriticalStrikeEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
                
            thisHero.HeroLogic.HeroEvents.BeforeCriticalStrike(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PreCriticalStrike(thisHero, targetHero);
                
            logicTree.EndSequence();
            yield return null;
        }
        private IEnumerator PostCriticalStrikeEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
                
            thisHero.HeroLogic.HeroEvents.AfterCriticalStrike(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PostCriticalStrike(thisHero, targetHero);
                
            logicTree.EndSequence();
            yield return null;
        }
        
        
        
        private IEnumerator BeforeCounterAttackEvents(IHero counterAttacker, IHero originalAttacker)
        {
                
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;
                
            counterAttacker.HeroLogic.HeroEvents.BeforeCounterAttack(counterAttacker,originalAttacker);
            originalAttacker.HeroLogic.HeroEvents.PreCounterAttack(counterAttacker,originalAttacker);
                
            logicTree.EndSequence();
            yield return null;
        }
            
        private IEnumerator AfterCounterAttackEvents(IHero counterAttacker, IHero originalAttacker)
        {
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;
                
            counterAttacker.HeroLogic.HeroEvents.AfterCounterAttack(counterAttacker,originalAttacker);
            originalAttacker.HeroLogic.HeroEvents.PostCounterAttack(counterAttacker,originalAttacker);
                
            logicTree.EndSequence();
            yield return null;
        }
    

    }
}
