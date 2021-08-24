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
        
        [SerializeField]
        private int _finalDamage;
        public int FinalDamage => _finalDamage;
        
        

        private void Awake()
        {
            _thisHeroLogic = GetComponent<IHeroLogic>();
           
        }

        private void Start()
        {
            _logicTree = _thisHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _thisHeroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }
        
        public IEnumerator TakeAllDamage(int normalDamage, int totalEnhancedDamage)
        {
            var thisHero = _thisHeroLogic.Hero;
            
            _logicTree.AddCurrent(HeroTakesDamage(normalDamage,totalEnhancedDamage));
            
            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(thisHero));

            _logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator TakeAllDamageIgnoreArmor(int normalDamage, int totalEnhancedDamage)
        {
            var thisHero = _thisHeroLogic.Hero;
            
            _logicTree.AddCurrent(HeroTakesDamage(normalDamage,totalEnhancedDamage));
            
            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(thisHero));

            _logicTree.EndSequence();
            yield return null;
        }
        
        
        private IEnumerator HeroTakesDamage(int normalDamage, int totalEnhancedDamage)
        {
             _finalDamage = ComputeFinalDamage(normalDamage, totalEnhancedDamage);

            ComputeNewArmor(_thisHeroLogic, _finalDamage);
            ComputeNewHealth(_thisHeroLogic, _residualDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamage(_finalDamage));
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator HeroTakesDamageIgnoreArmor(int normalDamage, int totalEnhancedDamage)
        {
            _finalDamage = ComputeFinalDamage(normalDamage, totalEnhancedDamage);
            
            ComputeNewHealth(_thisHeroLogic, _finalDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamage(_finalDamage));
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        
        
        
        private int ComputeFinalDamage(int normalDamage, int criticalDamage)
        {
           
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;

            //Don't Clamp - scenario:  Hero takes 15% additional damage - e.g. Target Debuff
            //damageReduction = Mathf.Clamp(damageReduction, 0, 1);

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
