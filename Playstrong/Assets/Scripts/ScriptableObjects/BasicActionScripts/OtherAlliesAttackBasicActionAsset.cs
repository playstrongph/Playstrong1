using System.Collections;
using System.Collections.Generic;
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
    /// Other allies attack after this hero action
    /// </summary>
    [CreateAssetMenu(fileName = "OtherAlliesAttackBasicAction", menuName = "SO's/BasicActions/O/OtherAlliesAttackBasicAction")]
    public class OtherAlliesAttackBasicActionAsset : BasicActionAsset
    {
        //Number of other allies that will attack
        [SerializeField] private int otherAllyAttackersCount;

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
        
      

    //TARGET ACTION    
    public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            foreach (var otherAlly in OtherAttackingAllies(thisHero,targetHero))
            {
                //Hero shouldn't be stunned,sleep, or disabled in any way
                if(thisHero.HeroLogic.OtherAttributes.HeroInabilityChance <=0)    
                    logicTree.AddCurrent(AttackHero(otherAlly,targetHero));
            }

            logicTree.EndSequence();
            yield return null;

        }

    private List<IHero> OtherAttackingAllies(IHero thisHero,IHero targetHero)
    {
        var allAllies = thisHero.LivingHeroes.LivingHeroesList;
        var otherAllies = new List<IHero>(ShuffleList(allAllies));
        var  allyAttackers = new List<IHero>();
        var allyCount = Mathf.Min(otherAllies.Count, otherAllyAttackersCount);
            
        otherAllies.Remove(thisHero);
        for (int i = 0; i < allyCount; i++)
        {
            allyAttackers.Add(otherAllies[i]);                
            Debug.Log("Other Ally " +otherAllies[i].HeroName);
        }

        return allyAttackers;
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
        
        var criticalChance = thisHero.HeroLogic.OtherAttributes.CriticalStrikeChance;
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
        var dealDamage = thisHero.HeroLogic.DealDamage;
        
        //Test - dealDamage should be thisHero not targetHero
        var dealDamageTest = thisHero.HeroLogic.DealDamageTest;
        
        var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
        var criticalFactor = 0;
        
        //TEST
        var nonCriticalAttackDamage =
            Mathf.CeilToInt(thisHero.HeroLogic.HeroAttributes.Attack + CalculatedAdditionalDamage.GetCalculatedValue() +flatAdditionalDamage);
        var criticalAttackDamage = Mathf.CeilToInt(criticalFactor * nonCriticalAttackDamage);
        
        //TODO: To be used after DealDamage change
        //var nonCriticalDamage = attackPower + AdditionalAttackDamage;
        //var criticalDamage = 0;
        
        //PRE-ATTACK PHASE
        logicTree.AddCurrent(PreSkillAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PreAttackEvents(thisHero,targetHero));

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
        
        //POST ATTACK PHASE
        logicTree.AddCurrent(PostAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PostSkillAttackEvents(thisHero,targetHero));
            
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
        logicTree.AddCurrent(PreSkillAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PreAttackEvents(thisHero,targetHero));
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
        logicTree.AddCurrent(PostAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PostSkillAttackEvents(thisHero,targetHero));
            
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
