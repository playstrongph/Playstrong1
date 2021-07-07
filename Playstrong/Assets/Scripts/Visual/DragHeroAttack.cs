using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using Logic;
using UnityEngine;

namespace Visual
{
    public class DragHeroAttack : MonoBehaviour, IDragHeroAttack
    {
        private ITargetHero _thisTargetHero;
        private ITargetHero _targetEnemyHero;

        private Action _basicAttackTarget;
        private Action _attackTargetHero;
        
        private List<IHero> _validTargets = new List<IHero>();
        private IHero _hero;

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IGetAttackTargets _getAttackTargets;
        private IBasicAttack _basicAttack;
        private IEndHeroTurn _endHeroTurn;
        
        
     
        private void Awake()
        {
            _thisTargetHero = GetComponent<ITargetHero>();
            _getAttackTargets = GetComponent<IGetAttackTargets>();
            
            _logicTree = _thisTargetHero.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _thisTargetHero.Hero.CoroutineTreesAsset.MainVisualTree;

            _basicAttack = _thisTargetHero.Hero.HeroLogic.BasicAttack;
            _endHeroTurn = _thisTargetHero.Hero.HeroLogic.EndHeroTurn;
            
            _basicAttackTarget = NoAction;
            _attackTargetHero = NoAction;
        }
        
        private void OnMouseUp()
        {
           _attackTargetHero();
        }

        private void OnMouseDown()
        {
            _basicAttackTarget = NoAction;
            _logicTree.AddCurrent(GetValidTargets());
          
        }

        public void EnableDragHeroAttack()
        {
            _attackTargetHero = AttackTargetHero;
        }

        public void DisableDragHeroAttack()
        {
            _attackTargetHero = NoAction;
        }


        private void AttackTargetHero()
        {
            _logicTree.AddCurrent(SetAttackTarget());
            
            _logicTree.AddCurrent(AttackTarget());
        }

        private IEnumerator AttackTarget()
        {
            _basicAttackTarget();
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator SetAttackTarget()
        {
            SetTarget();
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator GetValidTargets()
        {
            _validTargets = _getAttackTargets.GetValidEnemyTargets();

            yield return null;
            _logicTree.EndSequence();
        }
        
        private void SetTarget()
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
                       _basicAttackTarget = BasicAttackTarget;
                   }
                }
            }
        }

        private void BasicAttackTarget()
        {
            _logicTree.AddCurrent(_basicAttack.StartAttack(_thisTargetHero.Hero, _targetEnemyHero.Hero));
            _logicTree.AddCurrent(_endHeroTurn.EndTurn());
        }

        private void NoAction()
        {
            
        }

       


    }
}
