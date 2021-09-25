using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

public class SkillAttack : MonoBehaviour, ISkillAttack
{
    //Set by AttackBasicAction
    public int AdditionalAttackDamage { get; set; }
    
    
    //TODO: private IEnumerator StartAttackAction(IHero thisHero, IHero targetHero){}
    public IEnumerator StartSkillAttack(IHero thisHero, IHero targetHero, ISingleOrMultiAttackTypeAsset attackTargetType, IGameAnimations attackAnimation, float visualDelay)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
        
        logicTree.AddCurrent(SetNormalOrCriticalAttack(thisHero, targetHero,attackTargetType,attackAnimation,visualDelay));
        
        logicTree.EndSequence();
        yield return null;
    }
    
    //TODO: CounterAttack
    
    private IEnumerator SetNormalOrCriticalAttack(IHero thisHero, IHero targetHero, ISingleOrMultiAttackTypeAsset attackTargetType, IGameAnimations attackAnimation, float visualDelay)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
        var criticalChance = thisHero.HeroLogic.OtherAttributes.CriticalStrikeChance;
        var criticalResistance = thisHero.HeroLogic.OtherAttributes.CriticalStrikeResistance;
        var netChance = criticalChance - criticalResistance;
        var randomChance = Random.Range(0f, 100f);
        netChance = Mathf.Clamp(netChance, 0f, 100f);

        
        logicTree.AddCurrent(randomChance <= netChance
            ? CriticalAttack(thisHero, targetHero,attackTargetType,attackAnimation,visualDelay)
            : NormalAttack(thisHero, targetHero,attackTargetType,attackAnimation,visualDelay));

        logicTree.EndSequence();
        yield return null;
    }
    
    private IEnumerator NormalAttack(IHero thisHero, IHero targetHero, ISingleOrMultiAttackTypeAsset attackTargetType, IGameAnimations attackAnimation, float visualDelay)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
        var dealDamage = targetHero.HeroLogic.DealDamage;
        var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
        var criticalFactor = 0;
        
        //TODO: To be used after DealDamage change
        //var nonCriticalDamage = attackPower + AdditionalAttackDamage;
        //var criticalDamage = 0;
        
        //PRE-ATTACK PHASE
        logicTree.AddCurrent(PreSkillAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PreAttackEvents(thisHero,targetHero));

        //MAIN ATTACK PHASE
        
        //visuals
        logicTree.AddCurrent(AttackHeroAnimation(thisHero,targetHero,attackAnimation));
        
        //Single/Multiple Target TODO:Needs Improvement in Implementation
        logicTree.AddCurrent(attackTargetType.DealAttackDamage(dealDamage,thisHero, targetHero, attackPower, criticalFactor));
        
        //visuals
        logicTree.AddCurrent(AttackInterval(thisHero,targetHero,visualDelay));
        
        //POST ATTACK PHASE
        logicTree.AddCurrent(PostAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PostSkillAttackEvents(thisHero,targetHero));
            
        logicTree.EndSequence();
        yield return null;
    }
    
    private IEnumerator CriticalAttack(IHero thisHero, IHero targetHero, ISingleOrMultiAttackTypeAsset attackTargetType, IGameAnimations attackAnimation, float visualDelay)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
        var dealDamage = targetHero.HeroLogic.DealDamage;
        var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
        var criticalFactor = thisHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier/100;

        //TODO: To be used after DealDamage change
        //var nonCriticalDamage = attackPower + AdditionalAttackDamage;
        //var criticalDamage = Mathf.FloorToInt(criticalFactor*nonCriticalDamage);

        //PRE-ATTACK PHASE
        logicTree.AddCurrent(PreSkillAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PreAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PreCriticalStrikeEvents(thisHero,targetHero));

        //MAIN ATTACK PHASE
        
        //visuals
        logicTree.AddCurrent(AttackHeroAnimation(thisHero,targetHero,attackAnimation));
        
        //Single/Multiple Target TODO:Needs Improvement in Implementation
        logicTree.AddCurrent(attackTargetType.DealAttackDamage(dealDamage,thisHero, targetHero, attackPower, criticalFactor));
        
        //visuals
        logicTree.AddCurrent(AttackInterval(thisHero,targetHero,visualDelay));
        
        //POST ATTACK PHASE
        logicTree.AddCurrent(PostCriticalStrikeEvents(thisHero,targetHero));
        logicTree.AddCurrent(PostAttackEvents(thisHero,targetHero));
        logicTree.AddCurrent(PostSkillAttackEvents(thisHero,targetHero));
            
        logicTree.EndSequence();
        yield return null;
    }

    //VISUALS
    private IEnumerator AttackInterval(IHero thisHero, IHero targetHero, float visualDelay)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
        var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            
        //Inserts delay in seconds before calling visualTree.EndSequence()
        visualTree.AddCurrentWait(visualDelay, visualTree);
            
        logicTree.EndSequence();
        yield return null;
    }
    private IEnumerator AttackHeroAnimation(IHero thisHero, IHero targetHero, IGameAnimations attackAnimation)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
        var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;

        visualTree.AddCurrent(attackAnimation.StartAnimation(thisHero,targetHero));
            
        logicTree.EndSequence();
        yield return null;
    }

    //EVENTS
    private IEnumerator PreSkillAttackEvents(IHero thisHero, IHero targetHero)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
        thisHero.HeroLogic.HeroEvents.BeforeSkillAttacking(thisHero, targetHero);
        targetHero.HeroLogic.HeroEvents.PreSkillAttack(targetHero,thisHero);
            
        logicTree.EndSequence();
        yield return null;
    }
    private IEnumerator PreAttackEvents(IHero thisHero, IHero targetHero)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
        thisHero.HeroLogic.HeroEvents.BeforeAttacking(thisHero, targetHero);
        targetHero.HeroLogic.HeroEvents.PreAttack(targetHero,thisHero);
            
        logicTree.EndSequence();
        yield return null;
    }
    private IEnumerator PostSkillAttackEvents(IHero thisHero, IHero targetHero)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
        thisHero.HeroLogic.HeroEvents.AfterSkillAttacking(thisHero, targetHero);
        targetHero.HeroLogic.HeroEvents.PostSkillAttack(targetHero,thisHero);
            
        logicTree.EndSequence();
        yield return null;
    }
    private IEnumerator PostAttackEvents(IHero thisHero, IHero targetHero)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
        thisHero.HeroLogic.HeroEvents.AfterAttacking(thisHero, targetHero);
        targetHero.HeroLogic.HeroEvents.PostAttack(targetHero,thisHero);
            
        logicTree.EndSequence();
        yield return null;
    }
    private IEnumerator PreCriticalStrikeEvents(IHero thisHero, IHero targetHero)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
        thisHero.HeroLogic.HeroEvents.BeforeCriticalStrike(thisHero, targetHero);
        targetHero.HeroLogic.HeroEvents.PreCriticalStrike(targetHero, thisHero);
            
        logicTree.EndSequence();
        yield return null;
    }
    private IEnumerator PostCriticalStrikeEvents(IHero thisHero, IHero targetHero)
    {
        var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
        thisHero.HeroLogic.HeroEvents.AfterCriticalStrike(thisHero, targetHero);
        targetHero.HeroLogic.HeroEvents.PostCriticalStrike(targetHero, thisHero);
            
        logicTree.EndSequence();
        yield return null;
    }
}
