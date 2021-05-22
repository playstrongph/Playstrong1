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

        private void SetTargetLists()
        {
            var enemies = _targetHero.Hero.LivingHeroes.Player.OtherPlayer.LivingHeroes.HeroesList;
            foreach (var enemy in enemies)
            {
                var enemyHero = enemy.GetComponent<IHero>();
                enemyHero.HeroLogic.TargetStatus.AddToTargetList(enemyHero,_enemyNormalHeroes, _enemyTauntHeroes, _enemyStealthHeroes);
            }
        }

        private void SetStealthTargets()
        {
            foreach (var enemy in _enemyStealthHeroes)
            {
                //Do stealth effects here.
            }
        }

        private void SetTauntTargets()
        {
            foreach (var enemy in _enemyTauntHeroes)
            {
                _enemyNormalHeroes.Clear();
                _validTargets.Add(enemy);
            }
        }

        private void SetNormalTargets()
        {
            foreach (var enemy in _enemyNormalHeroes)
            {
                _validTargets.Add(enemy);
            }
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
