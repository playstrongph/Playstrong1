using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using Logic;
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

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IBasicAttackTargets _basicAttackTargets;
        
        
     
        private void Awake()
        {
            _targetHero = GetComponent<ITargetHero>();
            _basicAttackTargets = GetComponent<IBasicAttackTargets>();
            _logicTree = _targetHero.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _targetHero.Hero.CoroutineTreesAsset.MainVisualTree;
            
            _attackTarget = NoAction;
        }

        private void Start()
        {
            
        }

        private void OnMouseUp()
        {
           _logicTree.AddCurrent(SetAttackTarget());
           _logicTree.AddCurrent(AttackTarget());
           
           _visualTree.AddCurrent(HideTargetsGlow());
        }

        private void OnMouseDown()
        {
            _attackTarget = NoAction;
            _logicTree.AddCurrent(GetValidTargets());
            
            _visualTree.AddCurrent(ShowTargetsGlow());
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
            _validTargets = _basicAttackTargets.GetTargets();

            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator ShowTargetsGlow()
        {
            _basicAttackTargets.ShowBasicAttackTargetsGlow();
            
            yield return null;
            _visualTree.EndSequence();
        }
        
        private IEnumerator HideTargetsGlow()
        {
            _basicAttackTargets.HideBasicAttackTargetsGlow();
            yield return null;
            _visualTree.EndSequence();
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
