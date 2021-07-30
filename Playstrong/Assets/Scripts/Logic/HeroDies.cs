using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.HeroLivingStatus;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

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
            ResetHeroAttributes(hero);
            HideHeroVisuals(hero);
            DisableHeroTurns(hero);
            
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

        private void ResetHeroAttributes(IHero hero)
        {
            var heroAttributes = hero.HeroLogic.HeroAttributes;
            var heroLogic = hero.HeroLogic;

            //Only displayed in Hero Preview
            heroAttributes.Chance = heroAttributes.BaseChance;

            heroLogic.SetHeroAttack.SetAttack(heroAttributes.BaseAttack);
            heroLogic.SetHeroHealth.SetHealth(heroAttributes.BaseHealth);
            heroLogic.SetHeroArmor.SetArmor(heroAttributes.BaseArmor);
            heroLogic.SetHeroSpeed.SetSpeed(heroAttributes.BaseSpeed);
            heroLogic.HeroTimer.ResetHeroTimer();
        }

        private void HideHeroVisuals(IHero hero)
        {
            //Disable TargetVisual GameObject (Need to create reference for TargetHero)
            hero.TargetHero.TargetVisual.TargetCanvas.enabled = false;
            
            //Disable TargetHero BoxCollider
            hero.TargetHero.HeroBoxCollider.enabled = false;

            //TODO: Disable HeroVisual Canvas
        }

        private void DisableHeroTurns(IHero hero)
        {
            UpdateLivingAndDeadHeroLists(hero);
            UpdateActiveHeroesList(hero);
        }

        private void UpdateLivingAndDeadHeroLists(IHero hero)
        {
            var deadHeroes = hero.LivingHeroes.Player.DeadHeroes.HeroesList;
            var livingHeroes = hero.LivingHeroes.HeroesList;
            
            GameObject deadHeroGameObject = null;
            foreach (var heroGameObject in hero.LivingHeroes.HeroesList)
            {
                if (heroGameObject.GetComponent<IHero>() == hero)
                    deadHeroGameObject = heroGameObject;
            }

            livingHeroes.Remove(deadHeroGameObject);
            deadHeroes.Add(deadHeroGameObject);


        }
        
        /// <summary>
        /// If hero is active, removes hero from ActiveHeroes Queue and changes state to inactive
        /// </summary>
        private void UpdateActiveHeroesList(IHero hero)
        {
            var turnController = hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroInactiveStatus = turnController.SetHeroStatus.HeroInactive;
            var heroTimerObject = hero.HeroLogic.HeroTimer as Object;
            
            hero.HeroLogic.HeroStatus.RemoveFromActiveHeroesList(turnController, heroTimerObject);
            hero.HeroLogic.HeroStatus = heroInactiveStatus;
        }


    }
}
