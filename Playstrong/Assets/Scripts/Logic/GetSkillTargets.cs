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
        private Action _getValidTargets;

        private Action _showTargetsGlow;

        private void Awake()
        {
            _targetSkill = GetComponent<ITargetSkill>();
          

            _showTargetsGlow = NoAction;
        }
        
        public List<IHero> GetValidTargets()
        {
           
            _validTargets.Clear();
            
            _skillTarget = _targetSkill.Skill.SkillLogic.SkillAttributes.SkillTarget;
            _skillTarget.SetTargets(_getValidTargets, GetAllyTargets, GetEnemyTargets);

            _getValidTargets();
            
            return _validTargets;
        }


        private void GetAllyTargets()
        {
            var thisHero =  _targetSkill.Skill.Hero;
            var allies = thisHero.LivingHeroes.HeroesList;
            foreach (var ally in allies)
            {
                var allyHero = ally.GetComponent<IHero>();
                _validTargets.Add(allyHero);
            }
        }
        
        private void GetEnemyTargets()
        {
            SetEnemyTargetLists();
            SetEnemyStealthTargets();
            SetEnemyTauntTargets();
            SetEnemyNormalTargets();
            
           
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
        
        private void OnMouseDown()
        {
            //_showTargetsGlow();
        }

        private void OnMouseUp()
        {
            //HideSkillTargetsGlow();
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

        public void NoAction()
        {
            Debug.Log("No Valid Target List was set");
        }
        
        










        //New List Based on Allowed SkillTargets





    }
}
