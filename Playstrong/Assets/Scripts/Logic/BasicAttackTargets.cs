using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public class BasicAttackTargets : MonoBehaviour, IBasicAttackTargets
    {
        private ITargetHero _targetHero;
       
        private List<IHero> _validTargets = new List<IHero>();
        private List<IHero> _enemyHeroes = new List<IHero>();

        private Action _showTargetsGlow;
    
        private void Awake()
        {
            _targetHero = GetComponent<ITargetHero>();
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

        public List<IHero> GetTargets()
        {
            var enemies = _targetHero.Hero.LivingHeroes.Player.OtherPlayer.LivingHeroes.HeroesList;

            foreach (var enemy in enemies)
            {
                var enemyHero = enemy.GetComponent<IHero>();
                _enemyHeroes.Add(enemyHero);
            }
            //Temp
            
            _validTargets = _enemyHeroes;
            return _validTargets;
            
            //TODO: Check for Taunt
        }

        private void ShowBasicAttackTargetsGlow()
        {
            _validTargets = GetTargets();
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
