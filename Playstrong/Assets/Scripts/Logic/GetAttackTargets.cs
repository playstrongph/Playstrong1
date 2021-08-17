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
       
        private List<IHero> _validEnemyTargets = new List<IHero>();
        
        private List<IHero> _enemyNormalHeroes = new List<IHero>();
        private List<IHero> _enemyTauntHeroes = new List<IHero>();
        private List<IHero> _enemyStealthHeroes = new List<IHero>();
        

        private Action _showTargetsGlow;
        private float stealthChanceCompensation = 3000f;
    
        private void Awake()
        {
            _targetHero = GetComponent<ITargetHero>();
            _thisHero = _targetHero.Hero;
            
            _showTargetsGlow = NoAction;
            
        }
        
        public List<IHero> GetValidEnemyTargets()
        {
            _validEnemyTargets.Clear();
            GetTargets();
            return _validEnemyTargets;
        }

       
        private void GetTargets()
        {
            _validEnemyTargets.Clear();
            
            var enemiesObjects = _targetHero.Hero.LivingHeroes.Player.OtherPlayer.LivingHeroes.HeroesList;
            var allEnemiesStealthChance = AllStealthEnemies(enemiesObjects);
            var tauntEnemies = new List<IHero>();

            
            //this loop gets all non-stealth targets
            foreach (var enemyObject in enemiesObjects)
            {
                var enemy = enemyObject.GetComponent<IHero>();
                var netAttackTargetChance = enemy.HeroLogic.OtherAttributes.AttackTargetChance - enemy.HeroLogic.OtherAttributes.AttackTargetResistance;
                var netChance = netAttackTargetChance + allEnemiesStealthChance;

                if(netChance >= 100)
                    _validEnemyTargets.Add(enemy);
            }
            
            //this loop gets all taunt targets
            tauntEnemies.Clear();
            foreach (var validEnemyTarget in _validEnemyTargets)
            {
                var netAttackTargetChance = validEnemyTarget.HeroLogic.OtherAttributes.AttackTargetChance - validEnemyTarget.HeroLogic.OtherAttributes.AttackTargetResistance;
                var netChance = netAttackTargetChance;

                if (netChance >= 500)
                {
                    tauntEnemies.Add(validEnemyTarget);    
                }
            }

            if (tauntEnemies.Count > 0)
            {
                _validEnemyTargets.Clear();
                _validEnemyTargets = tauntEnemies;
            }
        }
        
        private float AllStealthEnemies(List<GameObject> enemiesObjects)
        {
            var allEnemiesStealthChance = 0f;
            var validTargets = 0f;

            foreach (var enemyObject in enemiesObjects)
            {
                var enemy = enemyObject.GetComponent<IHero>();
                var netAttackTargetChance = enemy.HeroLogic.OtherAttributes.AttackTargetChance - enemy.HeroLogic.OtherAttributes.AttackTargetResistance;

                if (netAttackTargetChance >= 100)
                    validTargets += 1;
            }
            
            //if all targets are stealth - i.e. if there are no valid targets
            if (validTargets < 1)
                allEnemiesStealthChance = stealthChanceCompensation;
            
            return allEnemiesStealthChance;
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
            _validEnemyTargets = GetValidEnemyTargets();
            foreach (var hero in _validEnemyTargets)
            {
                hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.EnemyGlowFrame.SetActive(true);
                
                
            }
        }
        
        private void HideBasicAttackTargetsGlow()
        {
            foreach (var hero in _validEnemyTargets)
            {
                hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.EnemyGlowFrame.SetActive(false);
            }
        }

        private void NoAction()
        {
        }


    }
}
