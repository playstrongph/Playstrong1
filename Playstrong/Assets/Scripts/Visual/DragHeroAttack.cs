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
        private ITargetHero _targetHero;
        private ITargetHero _targetEnemyHero;

        private Action _attackTarget;
        
        private List<IHero> _validTargets = new List<IHero>();
        private IHero _hero;

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IGetAttackTargets _getAttackTargets;
        
        
     
        private void Awake()
        {
            _targetHero = GetComponent<ITargetHero>();
            _getAttackTargets = GetComponent<IGetAttackTargets>();
            _logicTree = _targetHero.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _targetHero.Hero.CoroutineTreesAsset.MainVisualTree;
            _attackTarget = NoAction;
        }
        
        private void OnMouseUp()
        {
           _logicTree.AddCurrent(SetAttackTarget());
           _logicTree.AddCurrent(AttackTarget());
          
        }

        private void OnMouseDown()
        {
            _attackTarget = NoAction;
            _logicTree.AddCurrent(GetValidTargets());
          
        }
        
        private IEnumerator AttackTarget()
        {
            _attackTarget();
            
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
            _validTargets = _getAttackTargets.GetTargets();

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
                       _attackTarget = BasicAttackTarget;
                   }
                }
            }
        }

        private void BasicAttackTarget()
        {
            Debug.Log("Attack Hero:" +_targetEnemyHero.Hero.HeroName);
        }

        private void NoAction()
        {
            
        }

       


    }
}
