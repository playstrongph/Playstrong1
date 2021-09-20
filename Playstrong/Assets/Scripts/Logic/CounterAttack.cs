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
            _heroLogic.HeroEvents.EPostAttack += StartCounterAttack;
        }
        
         private void StartCounterAttack(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(CounterAttackCoroutine(thisHero,targetHero));
           
        }
        private IEnumerator CounterAttackCoroutine(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            var counterAttackChance = thisHero.HeroLogic.OtherAttributes.CounterAttackChance;
            var counterAttackResistance = targetHero.HeroLogic.OtherAttributes.CounterAttackResistance;
            
            var netCounterAttackChance = counterAttackChance - counterAttackResistance;
            netCounterAttackChance = Mathf.Clamp(netCounterAttackChance, 0f, 100f);
            var randomNumber = Random.Range(0f, 100f);

            if (randomNumber <= netCounterAttackChance)
            {
                logicTree.AddCurrent(BeforeCounterAttackEvents(thisHero,targetHero));
                logicTree.AddCurrent(_basicAttack.StartAttack(thisHero,targetHero));    
                logicTree.AddCurrent(AfterCounterAttackEvents(thisHero,targetHero));
            }

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator BeforeCounterAttackEvents(IHero thisHero, IHero targetHero)
        {
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeCounterAttack(thisHero,targetHero);
            targetHero.HeroLogic.HeroEvents.PreCounterAttack(targetHero,thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator AfterCounterAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterCounterAttack(thisHero,targetHero);
            targetHero.HeroLogic.HeroEvents.PostCounterAttack(targetHero,thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
