using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;

namespace Visual
{
    public class DragHeroAttack : MonoBehaviour
    {
        private ITargetHero _targetHero;
        private ITargetHero _targetEnemyHero;

        private Action _attackTarget;
        
        private List<IHero> _validTargets = new List<IHero>();
        private IHero _hero;
        private List<IHero> _enemyHeroes = new List<IHero>();
        
     
        private void Awake()
        {
            _targetHero = GetComponent<ITargetHero>();
            
            _attackTarget = NoAction;
        }

        private void OnMouseUp()
        {
            SetAttackTarget();
            _attackTarget();
        }

        private void OnMouseDown()
        {
            _attackTarget = NoAction;
            GetValidTargets();
        }

        private void SetAttackTarget()
        {
            var hits = Physics.RaycastAll(origin: Camera.main.transform.position, 
                direction: (-Camera.main.transform.position + this.transform.position).normalized, 
                maxDistance: 30f);
            
            Debug.Log("hits count" +hits.Length.ToString());
            Debug.DrawRay(Camera.main.transform.position, 
                (-Camera.main.transform.position + this.transform.position).normalized, 
                Color.red);

            foreach (var hit in hits)
            {
                if (hit.transform.GetComponent<ITargetHero>() != null)
                {
                    _hero = hit.transform.GetComponent<ITargetHero>().Hero;
                   
                   if (_hero.LivingHeroes.Player.OtherPlayer == _hero.LivingHeroes.Player)
                   {
                       _targetEnemyHero = hit.transform.GetComponent<ITargetHero>();
                       Debug.Log("Target Enemy Hero:" +_targetEnemyHero.Hero.HeroName);
                       
                       if(_validTargets.Contains(_targetEnemyHero.Hero))
                           _attackTarget = AttackTarget;
                                       
                   }
                }
            }
        }

        private void GetValidTargets()
        {
            var enemies = _targetHero.Hero.LivingHeroes.Player.OtherPlayer.LivingHeroes.HeroesList;

            foreach (var enemy in enemies)
            {
                var enemyHero = enemy.GetComponent<IHero>();
                _enemyHeroes.Add(enemyHero);
            }
            //Temp
            _validTargets = _enemyHeroes;
            
            
            
            //TODO: Check for Taunt
        }

        private void AttackTarget()
        {
            Debug.Log("Attack Hero:" +_targetHero.Hero.HeroName);
        }



        private void NoAction()
        {
            Debug.Log("No Action");
            
            Debug.Log("Target Hero:" +_targetHero.Hero.HeroName);
        }
    }
}
