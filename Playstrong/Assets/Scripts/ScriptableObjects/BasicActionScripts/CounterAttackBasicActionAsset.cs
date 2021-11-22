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
    /// Counter attacks with Basic Skill
    /// </summary>
    [CreateAssetMenu(fileName = "CounterAttackBasicAction", menuName = "SO's/BasicActions/C/CounterAttackBasicAction")]
    public class CounterAttackBasicActionAsset : BasicActionAsset
    {

        private int _antiCounterAttackResistance = 200;
        
        //TARGET ACTION    
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            //From the event: "thisHero" is the original attacker, "targetHero" is the counter-attacker
            if (targetHero.HeroLogic.OtherAttributes.HeroInabilityChance <= 0)
            {
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
            //Debug.Log("DEBUG123 CounterAttacker: " +counterAttacker.HeroName +" OriginalAttacker: " +originalAttacker.HeroName);
            
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;

            var counterAttackChance = counterAttacker.HeroLogic.OtherAttributes.CounterAttackChance;
            var counterAttackResistance = originalAttacker.HeroLogic.OtherAttributes.CounterAttackResistance 
                                          + originalAttacker.HeroLogic.OtherAttributes.AntiCounterAttackResistance;
            
            var netCounterAttackChance = counterAttackChance - counterAttackResistance;
            netCounterAttackChance = Mathf.Clamp(netCounterAttackChance, 1, 101);
            var randomNumber = Random.Range(0, 100);
            
            

            if (randomNumber <= netCounterAttackChance)
            {
                //Debug.Log("DEBUG123 CounterAttack Success: " +counterAttacker.HeroName);

                logicTree.AddCurrent(BeforeCounterAttackEvents(counterAttacker,originalAttacker));

                logicTree.AddCurrent(BasicSkillAttackHero(counterAttacker,originalAttacker));

                logicTree.AddCurrent(AfterCounterAttackEvents(counterAttacker,originalAttacker));
            }
            else
            {
                logicTree.AddCurrent(ReSetAntiCounterResistance(originalAttacker));

            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        
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

        private IEnumerator SetAntiCounterResistance(IHero counterAttacker)
        {
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("DEBUG123 SetAntiCounterResistance t0 200: " +counterAttacker.HeroName);
            
            //TEST
            counterAttacker.HeroLogic.OtherAttributes.AntiCounterAttackResistance = _antiCounterAttackResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator ReSetAntiCounterResistance(IHero originalAttacker)
        {
            var logicTree = originalAttacker.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("DEBUG123 SetAntiCounterResistance to ZERO: " +originalAttacker.HeroName);
            
            //TEST
            originalAttacker.HeroLogic.OtherAttributes.AntiCounterAttackResistance = 0;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        //EVENTS

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
