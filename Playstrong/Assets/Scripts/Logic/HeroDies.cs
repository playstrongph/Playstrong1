using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.HeroLivingStatus;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroDies : MonoBehaviour, IHeroDies
    {

        [SerializeField]
        [RequireInterface(typeof(IHeroLivingStatusAsset))]
        private ScriptableObject _heroLivingStatus;
        
        private IHeroLivingStatusAsset HeroLivingStatus => _heroLivingStatus as IHeroLivingStatusAsset;
        
        
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }


        public IEnumerator CheckHeroDeath(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(BeforeHeroDiesEvent(hero));

            logicTree.AddCurrent(HeroDiesAction(hero));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Event where possible death interruption to the hero is called
        /// Example - immortal, evade death skill, etc.
        /// </summary>
        private IEnumerator BeforeHeroDiesEvent(IHero hero)
        {
            var heroHealth = hero.HeroLogic.HeroAttributes.Health;
            
            if (heroHealth <= 0)
                hero.HeroLogic.HeroEvents.BeforeHeroDies(hero);

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
           
        }


        private IEnumerator HeroDiesAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            var heroHealth = hero.HeroLogic.HeroAttributes.Health;

            if (heroHealth <= 0)
            {
                logicTree.AddCurrent(HeroDeathActions(hero));
                logicTree.AddCurrent(AfterHeroDiesEvent(hero));
            }

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Event where hero death is confirmed.
        /// Example of actions here - revive, death rattle effects, etc.
        /// </summary>
        private IEnumerator AfterHeroDiesEvent(IHero hero)
        {
            hero.HeroLogic.HeroEvents.AfterHeroDies(hero);

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
           
        }

        private IEnumerator HeroDeathActions(IHero hero)
        {
            DeathActions(hero);
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        //TODO - Work In Progress
        private void DeathActions(IHero hero)
        {
            SetHeroDeadStatus(hero);
            DestroyAllStatusEffects(hero);
            //TODO: Reset Base Values
            //Remove from TurnController
            //Disable Skills
            //Disable Target Visuals

            //Note: Visual actions need to be queued.
        }

        private void SetHeroDeadStatus(IHero hero)
        {
            hero.HeroLogic.HeroLivingStatus = HeroLivingStatus;
        }

        private void DestroyAllStatusEffects(IHero hero)
        {
            var buffs = hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var debuffs = hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;

            foreach (var buff in buffs)
            {
                buff.RemoveStatusEffect.RemoveEffect(hero);
            }
            
            foreach (var debuff in debuffs)
            {
                debuff.RemoveStatusEffect.RemoveEffect(hero);
            }
        }


    }
}
