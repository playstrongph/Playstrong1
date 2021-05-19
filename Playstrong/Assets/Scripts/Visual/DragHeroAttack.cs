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
           
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            var hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.transform.GetComponent<ITargetHero>() != null)
                {
                   var targetHero = hit.transform.GetComponent<ITargetHero>();

                   if (_validTargets.Contains(targetHero.Hero))
                   {
                       _targetEnemyHero = targetHero;
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
            Debug.Log("Attack Hero:" +_targetEnemyHero.Hero.HeroName);
        }



        private void NoAction()
        {
            
        }
    }
}
