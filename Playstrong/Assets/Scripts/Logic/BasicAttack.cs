using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class BasicAttack : MonoBehaviour
    {
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IHeroLogic _heroLogic;
        private int _heroAttackPower;
        
        private int _targetArmor;
        private int _targetHealth;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
            _heroAttackPower = _heroLogic.HeroAttributes.Attack;
        }

        private void Start()
        {
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _heroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }

        public IEnumerator AttackTarget(IHeroLogic attackTarget)
        {
            _targetArmor = attackTarget.Hero.HeroLogic.HeroAttributes.Armor;
            _targetHealth = attackTarget.Hero.HeroLogic.HeroAttributes.Health;
            
            var finalDamage = _heroAttackPower;
            
            
            
            yield return null;
            _logicTree.EndSequence();
        }
        
        

        private int ComputeArmor(int armor, int damage)
        {
            var residualDamage = damage-armor;
            residualDamage = Mathf.Clamp(residualDamage, 0, armor + damage);

            var newArmor = armor - damage;
            newArmor = Mathf.Clamp(newArmor, 0, armor + damage);
            _targetArmor = newArmor;
            
            return residualDamage;

        }



    }
}
