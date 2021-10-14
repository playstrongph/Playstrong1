using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.HeroLivingStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;
using Visual.Animation;
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
        
        [SerializeField]
        [RequireInterface(typeof(IGameAnimations))]
        private Object _dieAnimation;
        private IGameAnimations DieAnimation => _dieAnimation as IGameAnimations;


        [SerializeField] private ScriptableObject _resurrectStatusEffect;
        private IStatusEffectAsset ResurrectStatusEffect => _resurrectStatusEffect as IStatusEffectAsset;
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }


        public IEnumerator CheckHeroDeath(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(HeroTakesFatalDamageEvent(hero));

            logicTree.AddCurrent(HeroDiesAction(hero));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Event where possible death interruption to the hero is called
        /// Example - immortal, evade death skill, etc.
        /// </summary>
        private IEnumerator HeroTakesFatalDamageEvent(IHero hero)
        {
            var heroHealth = hero.HeroLogic.HeroAttributes.Health;
            
            if (heroHealth <= 0)
                hero.HeroLogic.HeroEvents.HeroTakesFatalDamage(hero);

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
                logicTree.AddCurrent(PostHeroDeath(hero));
            }

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
        
        /// <summary>
        /// Event right after hero death.
        /// Death rattle actions are called here
        /// </summary>
        private IEnumerator AfterHeroDiesEvent(IHero hero)
        {
            hero.HeroLogic.HeroEvents.AfterHeroDies(hero);

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
           
        }

        /// <summary>
        /// This is where Resurrect is called
        /// </summary>
        private IEnumerator PostHeroDeath(IHero hero)
        {
            hero.HeroLogic.HeroEvents.PostHeroDeath(hero);
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }



        
        private void DeathActions(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //if hero is active, end turn
            //TEST
            //logicTree.AddCurrent(hero.HeroLogic.HeroStatus.EndHeroTurn(hero.HeroLogic));
            
            
            logicTree.AddCurrent(SetHeroDeadStatus(hero));
            
            logicTree.AddCurrent(DestroyAllStatusEffects(hero));
            logicTree.AddCurrent(UnRegisterSkills(hero));
            logicTree.AddCurrent(DisableHeroTurns(hero)); 
            
            
            //Visual
            logicTree.AddCurrent(HeroDiesAnimation(hero));
            logicTree.AddCurrent(HideHeroVisuals(hero));
            logicTree.AddCurrent(ResetHeroAttributes(hero));
            
            //TODO: EndHeroTurn Enumerator
            logicTree.AddCurrent(EndActiveHeroTurn(hero));
            

            //TODO: UpdateHeroStatus Enumerator
            logicTree.AddCurrent(SetHeroInactiveStatus(hero));
            
           
            
        }

        private IEnumerator SetHeroDeadStatus(IHero hero)
        {
            hero.HeroLogic.HeroLivingStatus = HeroLivingStatus;

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator DestroyAllStatusEffects(IHero hero)
        {
            var buffs = hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var debuffs = hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var uniqueEffects = hero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;

            //It is correct to call the asset and not the buff due to buffs/debuffs that should not be destroyed on death
            //Extinction and Resurrect
            
            foreach (var buff in buffs)
            {
                buff.StatusEffectAsset.RemoveStatusEffectOnDeath(hero,buff);
            }
            
            foreach (var debuff in debuffs)
            {
                debuff.StatusEffectAsset.RemoveStatusEffectOnDeath(hero,debuff);
            }
            
            foreach (var uniqueEffect in uniqueEffects)
            {
                uniqueEffect.StatusEffectAsset.RemoveStatusEffectOnDeath(hero,uniqueEffect);
            }
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator UnRegisterSkills(IHero hero)
        {
            var heroSkillsReference = hero.HeroSkills.Skills;
            var heroSkillsObjects = heroSkillsReference.GetComponent<ISkillsPanel>().SkillList;

            foreach (var skillObject in heroSkillsObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                skill.SkillLogic.SkillAttributes.SkillEffect.UnregisterSkillEffect(skill);
            }
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator HideHeroVisuals(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            visualTree.AddCurrent(HideVisuals(hero));
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator ResetHeroAttributes(IHero hero)
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
            
            //TODO: Also reset Other Attributes
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DisableHeroTurns(IHero hero)
        {
            UpdateLivingAndDeadHeroLists(hero);
            
            //This should be an enumerator
            UpdateActiveHeroesList(hero);
            
            //TEST - this should be an enumerator
            //UpdateHeroStatus(hero);
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator HeroDiesAnimation(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(DieAnimation.StartAnimation(hero));
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
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
            
            //Transfer to UpdateHeroStatus
            //hero.HeroLogic.HeroStatus = heroInactiveStatus;
        }
        
        private IEnumerator SetHeroInactiveStatus(IHero hero)
        {
            Debug.Log("Set Hero Inactive Status");
            var turnController = hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroInactiveStatus = turnController.SetHeroStatus.HeroInactive;
            //var heroCurrentStatus = hero.HeroLogic.HeroStatus;
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

            //TEST
            //logicTree.AddCurrent(heroCurrentStatus.EndHeroTurn(hero.HeroLogic));
            
            hero.HeroLogic.HeroStatus = heroInactiveStatus;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator EndActiveHeroTurn(IHero hero)
        {
            Debug.Log("End Active Hero Turn:" ); 
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //var turnController = hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            //var heroInactiveStatus = turnController.SetHeroStatus.HeroInactive;
            var heroCurrentStatus = hero.HeroLogic.HeroStatus;

            logicTree.AddCurrent(heroCurrentStatus.EndHeroTurn(hero.HeroLogic));
            
            logicTree.EndSequence();
            yield return null;
        }
        
          
        
        
        private IEnumerator HideVisuals(IHero hero)
        {
            hero.TargetHero.TargetVisual.TargetCanvas.enabled = false;
            hero.TargetHero.HeroBoxCollider.enabled = false;
            hero.HeroVisual.HeroCanvas.enabled = false;
            
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            visualTree.EndSequence();
            yield return null;
        }
        
        

        






    }
}
