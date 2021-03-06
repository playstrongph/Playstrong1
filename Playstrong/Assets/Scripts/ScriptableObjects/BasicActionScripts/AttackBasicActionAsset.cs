using System.Collections;
using Interfaces;
using Logic;
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
    [CreateAssetMenu(fileName = "AttackBasicAction", menuName = "SO's/BasicActions/A/AttackBasicAction")]
    public class AttackBasicActionAsset : BasicActionAsset
    {
        [Header("CRITICAL STRIKE FACTORS")] 
        [SerializeField] private int defaultSkillCriticalChance = 0;

        [SerializeField] private int defaultAdditionalCriticalDamage = 0;


        [Header("DAMAGE FACTORS")]
        //To be used after revision of DealDamage/TakeDamage
        [SerializeField] private int flatAdditionalDamage;
        
        //To be used after revision of DealDamage/TakeDamage
        [SerializeField] private ScriptableObject calculatedAdditionalDamage;
        private ICalculatedFactorValueAsset CalculatedAdditionalDamage => calculatedAdditionalDamage as ICalculatedFactorValueAsset;

        [Header("ATTACK ANIMATION")]
        [SerializeField] private ScriptableObject attackAnimation;
        private IGameAnimations AttackAnimation => attackAnimation as IGameAnimations;

        [Header("ATTACK TARGET TYPE")] [SerializeField]
        private ScriptableObject singleOrMultiAttack;
        private ISingleOrMultiAttackTypeAsset SingleOrMultiAttack => singleOrMultiAttack as ISingleOrMultiAttackTypeAsset;
        
        [SerializeField]
        private float _visualDelay = 0.7f;

        private int _finalAttackValue;    

    //TARGET ACTION    
    public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            //Hero shouldn't be stunned,sleep, or disabled in any way
            if(thisHero.HeroLogic.OtherAttributes.HeroInabilityChance <=0)    
                logicTree.AddCurrent(AttackHero(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;

        }

    private IEnumerator AttackHero(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            //PreAttack Phase
            logicTree.AddCurrent(PreSkillAttackEvents(thisHero,targetHero));
            logicTree.AddCurrent(PreAttackEvents(thisHero,targetHero));

            //Main Attack Phase
            logicTree.AddCurrent(SetNormalOrCriticalAttack(thisHero,targetHero));

            //Post Attack Phase
            logicTree.AddCurrent(PostAttackEvents(thisHero,targetHero));
            logicTree.AddCurrent(PostSkillAttackEvents(thisHero,targetHero));

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
        //Debug.Log("Normal Attack: ");
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
        
        //TODO: Obsolete.  Delete during refactoring, currently being used by DragHeroAttack(which shall be removed)
        //var dealDamage = thisHero.HeroLogic.DealDamage;
        //var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
        
        
        var dealDamageTest = thisHero.HeroLogic.DealDamageTest;
        
        var criticalFactor = 0;
        
        
        var nonCriticalAttackDamage =
            Mathf.CeilToInt(thisHero.HeroLogic.HeroAttributes.Attack + CalculatedAdditionalDamage.GetCalculatedValue() +flatAdditionalDamage);
        var criticalAttackDamage = Mathf.CeilToInt(criticalFactor * nonCriticalAttackDamage);
        
        

        //MAIN ATTACK PHASE
        //visuals
        logicTree.AddCurrent(AttackHeroAnimation(thisHero,targetHero));

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
        //var dealDamage = thisHero.HeroLogic.DealDamage;
        //var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
        
        
        var dealDamageTest = thisHero.HeroLogic.DealDamageTest;
        
        var criticalFactor = (thisHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier + defaultAdditionalCriticalDamage)/100f ;
        
        //TEST
        var nonCriticalAttackDamage =
            Mathf.CeilToInt(thisHero.HeroLogic.HeroAttributes.Attack + CalculatedAdditionalDamage.GetCalculatedValue() +flatAdditionalDamage);
        var criticalAttackDamage = Mathf.CeilToInt(criticalFactor * nonCriticalAttackDamage);

        logicTree.AddCurrent(PreCriticalStrikeEvents(thisHero,targetHero));

        //MAIN ATTACK PHASE
        
        //VISUALS
        logicTree.AddCurrent(AttackHeroAnimation(thisHero,targetHero));

        logicTree.AddCurrent(SingleOrMultiAttack.DealAttackDamageTest(dealDamageTest,thisHero, targetHero, nonCriticalAttackDamage, criticalAttackDamage));
        
        //VISUALS
        logicTree.AddCurrent(AttackInterval(thisHero,targetHero));
        
        //POST ATTACK PHASE
        logicTree.AddCurrent(PostCriticalStrikeEvents(thisHero,targetHero));

        logicTree.EndSequence();
        yield return null;
    }
    
    //AUXILIARY METHODS
    private IEnumerator ResetAntiCounterResistance(IHero thisHero)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree; 
            
        thisHero.HeroLogic.OtherAttributes.AntiCounterAttackResistance = 0;
        
        //Debug.Log("thisHero: " +thisHero.HeroName +" Increase CounterResistance: " +thisHero.HeroLogic.OtherAttributes.CounterAttackResistance );

        logicTree.EndSequence();
        yield return null;
    }
    
    /*private IEnumerator ResetSkillCounterAttackResistance(IHero thisHero)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree; 
            
        thisHero.HeroLogic.OtherAttributes.CounterAttackResistance -= defaultSkillCounterAttackResistance;
        
        Debug.Log("thisHero: " +thisHero.HeroName +" Decrease CounterResistance: " +thisHero.HeroLogic.OtherAttributes.CounterAttackResistance );

        logicTree.EndSequence();
        yield return null;
    }*/


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

    }
}
