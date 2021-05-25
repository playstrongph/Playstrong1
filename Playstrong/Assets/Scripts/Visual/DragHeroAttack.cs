﻿using System;
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
        private ITargetHero _targetThisHero;
        private ITargetHero _targetEnemyHero;

        private Action _attackTarget;
        
        private List<IHero> _validTargets = new List<IHero>();
        private IHero _hero;

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IGetAttackTargets _getAttackTargets;
        private IBasicAttack _basicAttack;
        private IEndHeroTurn _endHeroTurn;
        
        
     
        private void Awake()
        {
            _targetThisHero = GetComponent<ITargetHero>();
            _getAttackTargets = GetComponent<IGetAttackTargets>();
            _logicTree = _targetThisHero.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _targetThisHero.Hero.CoroutineTreesAsset.MainVisualTree;

            _basicAttack = _targetThisHero.Hero.HeroLogic.BasicAttack;
            _endHeroTurn = _targetThisHero.Hero.HeroLogic.EndHeroTurn;
            
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
            _validTargets = _getAttackTargets.GetValidTargets();

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
        
        //Temp - this should be a separate component - BasicAttack

        private void BasicAttackTarget()
        {
            _logicTree.AddCurrent(_basicAttack.BasicAttackHero(_targetEnemyHero.Hero));
            _logicTree.AddCurrent(_endHeroTurn.EndTurn());
        }

        private void NoAction()
        {
            
        }

       


    }
}
