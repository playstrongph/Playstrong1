using System;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums.SkillTarget;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class GetSkillTargets : MonoBehaviour, IGetSkillTargets
    {
        private ITargetSkill _targetSkill;

      
        private ISkillTarget _skillTarget;
        
        private List<IHero> _validTargets = new List<IHero>();
        
        private List<IHero> _enemyNormalHeroes = new List<IHero>();
        private List<IHero> _enemyTauntHeroes = new List<IHero>();
        private List<IHero> _enemyStealthHeroes = new List<IHero>();

        /// <summary>
        /// This is set by the skillTarget Asset
        /// Can either be EnemyTargets or AllyTargets
        /// </summary>
        private List<Action> _getValidTargets = new List<Action>();
        
        private Action _showTargetsGlow;

        private int _targetIndex = 0;
        private float stealthChanceCompensation = 3000f;

        public int TargetIndex
        {
            get => _targetIndex;
            set => _targetIndex = value;
        }

        private void Awake()
        {
            _targetSkill = GetComponent<ITargetSkill>();
            
            _getValidTargets.Add(GetEnemyTargets);
            _getValidTargets.Add(GetAllyTargets);
            _getValidTargets.Add(NoAction);
            _getValidTargets.Add(GetOtherAllyTargets);

            _showTargetsGlow = NoAction;
        }
        
        private void OnMouseDown()
        {
            _showTargetsGlow();
        }

        private void OnMouseUp()
        {
            HideSkillTargetsGlow();
        }

        public List<IHero> GetValidTargets()
        {
           
            _validTargets.Clear();
            
            _skillTarget = _targetSkill.Skill.SkillLogic.SkillAttributes.SkillTarget;
            
            //TODO: Improve this
            _skillTarget.SetTargetIndex(this);

            //Enemy or Ally Targets
            _getValidTargets[TargetIndex]();
            
            return _validTargets;
        }


        private void GetAllyTargets()
        {

            var thisHero =  _targetSkill.Skill.Hero;
            _validTargets.Clear();
            
            _validTargets = new List<IHero>(thisHero.GetAllLivingAllyHeroes());
        }
        
        private void GetOtherAllyTargets()
        {
            var thisHero =  _targetSkill.Skill.Hero;
            _validTargets.Clear();
            
            _validTargets = new List<IHero>(thisHero.GetAllOtherLivingAllyHeroes());
        }

        private void GetEnemyTargets()
        {
            _validTargets.Clear();
            var targetHero = _targetSkill.Skill.Hero;
            
            var enemiesObjects = targetHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.HeroesList;
            var allEnemiesStealthChance = AllStealthEnemies(enemiesObjects);
            var tauntEnemies = new List<IHero>();

            
            //this loop gets all non-stealth targets
            foreach (var enemyObject in enemiesObjects)
            {
                var enemy = enemyObject.GetComponent<IHero>();
                var netAttackTargetChance = enemy.HeroLogic.OtherAttributes.AttackTargetChance - enemy.HeroLogic.OtherAttributes.AttackTargetResistance;
                var netChance = netAttackTargetChance + allEnemiesStealthChance;

                if(netChance >= 100)
                    _validTargets.Add(enemy);
            }
            
            //this loop gets all taunt targets
            tauntEnemies.Clear();
            foreach (var validEnemyTarget in _validTargets)
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
                _validTargets.Clear();
                _validTargets = tauntEnemies;
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
        
        private void SetEnemyTargetLists()
        {
            var thisHero =  _targetSkill.Skill.Hero;
            var enemies = thisHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.HeroesList;
            foreach (var enemy in enemies)
            {
                var enemyHero = enemy.GetComponent<IHero>();
                enemyHero.HeroLogic.TargetStatus.AddToTargetList(enemyHero,_enemyNormalHeroes, _enemyTauntHeroes, _enemyStealthHeroes);
            }
        }   
        
        private void SetEnemyStealthTargets()
        {
            foreach (var enemy in _enemyStealthHeroes)
            {
                //Do stealth effects here.
            }
        }
        
        private void SetEnemyTauntTargets()
        {
            foreach (var enemy in _enemyTauntHeroes)
            {
                _enemyNormalHeroes.Clear();
                _validTargets.Add(enemy);
            }
        }
        
        private void SetEnemyNormalTargets()
        {
            foreach (var enemy in _enemyNormalHeroes)
            {
                _validTargets.Add(enemy);
            }
        }
        
        

        public void EnableGlows()
        {
            _showTargetsGlow = ShowSkillTargetsGlow;
        }

        public void DisableGlows()
        {
            _showTargetsGlow = NoAction;
        }

        private void ShowSkillTargetsGlow()
        {
            _validTargets = GetValidTargets();
            foreach (var hero in _validTargets)
            {
              var glowFrameObject = _skillTarget.SetTargetGlows(hero);
              glowFrameObject.SetActive(true);
            }
        }
        
        
        private void HideSkillTargetsGlow()
        {
            foreach (var hero in _validTargets)
            {
                var glowFrameObject = _skillTarget.SetTargetGlows(hero);
                glowFrameObject.SetActive(false);
            }
        }

        private void NoAction()
        {
           
        }
        
        










        //New List Based on Allowed SkillTargets





    }
}
