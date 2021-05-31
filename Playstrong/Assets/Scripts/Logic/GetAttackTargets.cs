using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public class GetAttackTargets : MonoBehaviour, IGetAttackTargets
    {
        private ITargetHero _targetHero;
        private IHero _thisHero;
       
        private List<IHero> _validTargets = new List<IHero>();
        
        private List<IHero> _enemyNormalHeroes = new List<IHero>();
        private List<IHero> _enemyTauntHeroes = new List<IHero>();
        private List<IHero> _enemyStealthHeroes = new List<IHero>();
        

        private Action _showTargetsGlow;
    
        private void Awake()
        {
            _targetHero = GetComponent<ITargetHero>();
            _thisHero = _targetHero.Hero;
            
            _showTargetsGlow = NoAction;
            
        }
        
        public List<IHero> GetValidTargets()
        {
            //Note: Sequence of method calls is important
            _validTargets.Clear();
            
            SetTargetLists();
            
            SetStealthTargets();
            SetTauntTargets();
            SetNormalTargets();
            return _validTargets;
        }
        
        /// <summary>
        /// Adds all enemies to the respective lists of normal heroes, stealth heroes, and taunt heroes
        /// the list is populated using a scriptable object implementing the interface ITargetStatus 
        /// </summary>
        private void SetTargetLists()
        {
            var enemies = _targetHero.Hero.LivingHeroes.Player.OtherPlayer.LivingHeroes.HeroesList;
            foreach (var enemy in enemies)
            {
                var enemyHero = enemy.GetComponent<IHero>();
                enemyHero.HeroLogic.TargetStatus.AddToTargetList(enemyHero,_enemyNormalHeroes, _enemyTauntHeroes, _enemyStealthHeroes);
            }
        }   
        
        /// <summary>
        /// If a stealth hero is present, remove it from the validTargets list 
        /// </summary>

        private void SetStealthTargets()
        {
            foreach (var enemy in _enemyStealthHeroes)
            {
                //Do stealth effects here.
            }
        }
        
        /// <summary>
        /// If a taunt hero is present, clear the normal enemies list and add
        /// only the taunt heroes in the validTargets list
        /// </summary>

        private void SetTauntTargets()
        {
            foreach (var enemy in _enemyTauntHeroes)
            {
                _enemyNormalHeroes.Clear();
                _validTargets.Add(enemy);
            }
        }
        
        /// <summary>
        /// Add enemy heroes to the validTargets list
        /// this method is called after stealth and taunt target processing
        /// </summary>

        private void SetNormalTargets()
        {
            foreach (var enemy in _enemyNormalHeroes)
            {
                _validTargets.Add(enemy);
            }
        }
        
        private void OnMouseDown()
        {
            _showTargetsGlow();
        }

        private void OnMouseUp()
        {
            HideBasicAttackTargetsGlow();
            
        }

        public void EnableGlows()
        {
            _showTargetsGlow = ShowBasicAttackTargetsGlow;
        }
        
        public void DisableGlows()
        {
            _showTargetsGlow = NoAction;
            
        }

        private void ShowBasicAttackTargetsGlow()
        {
            _validTargets = GetValidTargets();
            foreach (var hero in _validTargets)
            {
                hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.EnemyGlowFrame.SetActive(true);
            }
        }
        
        private void HideBasicAttackTargetsGlow()
        {
            foreach (var hero in _validTargets)
            {
                hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.EnemyGlowFrame.SetActive(false);
            }
        }

        private void NoAction()
        {
        }


    }
}
