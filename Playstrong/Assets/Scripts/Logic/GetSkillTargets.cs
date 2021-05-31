using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class GetSkillTargets : MonoBehaviour, IGetSkillTargets
    {
        private ITargetSkill _targetSkill;

        private IHero _thisHero;
        
        private List<IHero> _validTargets = new List<IHero>();
        
        private List<IHero> _enemyNormalHeroes = new List<IHero>();
        private List<IHero> _enemyTauntHeroes = new List<IHero>();
        private List<IHero> _enemyStealthHeroes = new List<IHero>();

        /// <summary>
        /// This is set by the skillTarget Asset
        /// Can either be EnemyTargets or AllyTargets
        /// </summary>
        private Action _getValidTargets;

        private void Awake()
        {
            _targetSkill = GetComponent<ITargetSkill>();
            _thisHero = _targetSkill.Skill.Hero;
        }
        
        public List<IHero> GetValidTargets()
        {
            //Note: Sequence of method calls is important
            _validTargets.Clear();

            _getValidTargets();
            
            return _validTargets;
        }


        private void GetAllyTargets()
        {
            var allies = _thisHero.LivingHeroes.HeroesList;
            foreach (var ally in allies)
            {
                var allyHero = ally.GetComponent<IHero>();
                _validTargets.Add(allyHero);
            }
        }
        
        private void GetEnemyTargets()
        {
            SetnemyTargetLists();
            SetEnemyStealthTargets();
            SetEnemyTauntTargets();
            SetEnemyNormalTargets();
        }
        
        private void SetnemyTargetLists()
        {
            var enemies = _thisHero.LivingHeroes.Player.OtherPlayer.LivingHeroes.HeroesList;
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
        
        

        public void NoAction()
        {
            Debug.Log("No Valid Target List was set");
        }










        //New List Based on Allowed SkillTargets





    }
}
