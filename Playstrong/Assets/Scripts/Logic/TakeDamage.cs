using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class TakeDamage : MonoBehaviour
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

        public IEnumerator DamageTarget(IHeroLogic attackTarget)
        {
            _targetArmor = attackTarget.Hero.HeroLogic.HeroAttributes.Armor;
            _targetHealth = attackTarget.Hero.HeroLogic.HeroAttributes.Health;
            
            var finalDamage = _heroAttackPower;
            var residualDamage = DamageTargetArmor(_targetArmor, finalDamage);
            DamageTargetHealth(_targetHealth, residualDamage);

            yield return null;
            _logicTree.EndSequence();
        }

        private int DamageTargetArmor(int armor, int damage)
        {
            var residualDamage = damage-armor;
            residualDamage = Mathf.Clamp(residualDamage, 0, armor + damage);

            var newArmor = armor - damage;
            newArmor = Mathf.Clamp(newArmor, 0, armor + damage);
            _targetArmor = newArmor;
            
            return residualDamage;
        }
        
        private void DamageTargetHealth(int health, int damage)
        {
            var newHealth = health - damage;
            newHealth = Mathf.Clamp(newHealth, 0, health + damage);
            _targetHealth = newHealth;

        }


    }
}
