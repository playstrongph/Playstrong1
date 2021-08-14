using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class TakeDamage : MonoBehaviour, ITakeDamage
    {
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IHeroLogic _thisHeroLogic;
        private int _residualDamage;
        
        

        private void Awake()
        {
            _thisHeroLogic = GetComponent<IHeroLogic>();
           
        }

        private void Start()
        {
            _logicTree = _thisHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _thisHeroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }
        
        public IEnumerator DamageHero(int normalDamage, int criticalDamage, IHero attacker)
        {
            var thisHero = _thisHeroLogic.Hero;
            
            _logicTree.AddCurrent(HeroTakesDamage(normalDamage,criticalDamage,attacker));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(thisHero));

            _logicTree.EndSequence();
            yield return null;
          
        }
        
        private IEnumerator HeroTakesDamage(int normalDamage, int criticalDamage, IHero attacker)
        {
            var finalDamage = ComputeFinalDamage(normalDamage, criticalDamage);

            ComputeNewArmor(_thisHeroLogic, finalDamage);
            ComputeNewHealth(_thisHeroLogic, _residualDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamage(finalDamage));
            
            _logicTree.EndSequence();
            yield return null;
           
        }
        private int ComputeFinalDamage(int normalDamage, int criticalDamage)
        {
           
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            damageReduction = Mathf.Clamp(damageReduction, 0, 1);

            var floatFinalDamage = (1 - damageReduction) * (normalDamage + criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }

        private IEnumerator ApplyFinalDamage(int damageValue)
        {
            Debug.Log("ApplyFinalDamage Start: " +_thisHeroLogic.Hero.HeroName);
            
            var armor = _thisHeroLogic.HeroAttributes.Armor;
            var health = _thisHeroLogic.HeroAttributes.Health;
            
            _thisHeroLogic.Hero.DamageEffect.ShowDamage(damageValue);
            _thisHeroLogic.SetHeroArmor.SetArmor(armor);
            _thisHeroLogic.SetHeroHealth.SetHealth(health);
            
            Debug.Log("ApplyFinalDamage End: " +_thisHeroLogic.Hero.HeroName);

            _visualTree.EndSequence();
            yield return null;
          
        }

        private void ComputeNewArmor(IHeroLogic heroLogic, int damage)
        {
            var armor = heroLogic.HeroAttributes.Armor;
            
            _residualDamage = damage-armor;
            _residualDamage = Mathf.Clamp(_residualDamage, 0, armor + damage);

            var newArmor = armor - damage;
            newArmor = Mathf.Clamp(newArmor, 0, armor + damage);

            heroLogic.HeroAttributes.Armor = newArmor;

        }
        
        private void ComputeNewHealth(IHeroLogic heroLogic, int damage)
        {
            var health = heroLogic.HeroAttributes.Health;
            var newHealth = health - damage;
            
            heroLogic.HeroAttributes.Health = newHealth;
        }

       
        
        


    }
}
