using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic
{
    public class CounterAttack : MonoBehaviour, ICounterAttack
    {
        private IHeroLogic _heroLogic;
        private IBasicAttack _basicAttack;


        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
            _basicAttack = _heroLogic.BasicAttack;
        }

        private void Start()
        {
            //thisHero is the attacker, targetHero is the counterattacker
            _heroLogic.HeroEvents.EPostAttack += StartCounterAttack;
        }
        
         private void StartCounterAttack(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //From the event: "thisHero" is the original attacker, "targetHero" is the counter-attacker
            logicTree.AddCurrent(CounterAttackCoroutine(targetHero,thisHero));
           
        }
        private IEnumerator CounterAttackCoroutine(IHero counterAttacker, IHero originalAttacker)
        {
            var logicTree = counterAttacker.CoroutineTreesAsset.MainLogicTree;
            
            var counterAttackChance = counterAttacker.HeroLogic.OtherAttributes.CounterAttackChance;
            var counterAttackResistance = originalAttacker.HeroLogic.OtherAttributes.CounterAttackResistance;
            
            var netCounterAttackChance = counterAttackChance - counterAttackResistance;
            netCounterAttackChance = Mathf.Clamp(netCounterAttackChance, 0f, 100f);
            var randomNumber = Random.Range(0f, 100f);

            if (randomNumber <= netCounterAttackChance)
            {
                logicTree.AddCurrent(BeforeCounterAttackEvents(counterAttacker,originalAttacker));
                
                //logicTree.AddCurrent(_basicAttack.StartAttack(counterAttacker,originalAttacker));

                logicTree.AddCurrent(AfterCounterAttackEvents(counterAttacker,originalAttacker));
            }

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
