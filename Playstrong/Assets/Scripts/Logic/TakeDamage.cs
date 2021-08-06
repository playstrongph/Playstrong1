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
        [SerializeField] [RequireInterface(typeof(IModifier))]
        private List<ScriptableObject> _damageModifiers = new List<ScriptableObject>();

        public List<IModifier> DamageModifiers
        {
            get
            {
                var damageModifiers = new List<IModifier>();
                foreach (var damageMod in _damageModifiers)
                {
                    var damageModifier = damageMod as IModifier;
                    damageModifiers.Add(damageModifier);
                }

                return damageModifiers;
            }
        }


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

        public IEnumerator DamageHero(int damageValue, IHero attacker)
        {
            var thisHero = _thisHeroLogic.Hero;
            
            _logicTree.AddCurrent(HeroTakesDamage(damageValue, attacker));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(thisHero));

            _logicTree.EndSequence();
            yield return null;
          
        }

        private IEnumerator HeroTakesDamage(int damageValue, IHero attacker)
        {
            var finalDamage = ComputeFinalDamage(damageValue);

            ComputeNewArmor(_thisHeroLogic, finalDamage);
            ComputeNewHealth(_thisHeroLogic, _residualDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamage(finalDamage));
            
            _logicTree.EndSequence();
            yield return null;
           
        }
        
        public void AddToDamageModifiersList(IModifier modifier)
        {
            var modifierObject = modifier as ScriptableObject;
            DamageModifiers.Add(modifier);
            _damageModifiers.Add(modifierObject);
        }
        
        public void RemoveFromDamageModifiersList(IModifier modifier)
        {
            var modifierObject = modifier as ScriptableObject;
            DamageModifiers.Remove(modifier);
            _damageModifiers.Remove(modifierObject);
        }


        private int ComputeFinalDamage(int value)
        {
            var damage = value;
            
            foreach (var damageMod in DamageModifiers)
            {
                var modifier = damageMod.ModValue;
                damage = (int) Mathf.Ceil(damage * (1 + modifier));
            }
            return damage;
        }
        
        //TEST START
        public IEnumerator DamageHeroTest(int normalDamage, int criticalDamage, IHero attacker)
        {
            var thisHero = _thisHeroLogic.Hero;
            
            _logicTree.AddCurrent(HeroTakesDamageTest(normalDamage,criticalDamage,attacker));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(thisHero));

            _logicTree.EndSequence();
            yield return null;
          
        }
        
        private IEnumerator HeroTakesDamageTest(int normalDamage, int criticalDamage, IHero attacker)
        {
            var finalDamage = ComputeFinalDamageTest(normalDamage, criticalDamage);

            ComputeNewArmor(_thisHeroLogic, finalDamage);
            ComputeNewHealth(_thisHeroLogic, _residualDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamage(finalDamage));
            
            _logicTree.EndSequence();
            yield return null;
           
        }
        
        
        private int ComputeFinalDamageTest(int normalDamage, int criticalDamage)
        {
            
            var criticalDamageReductionFactor = _thisHeroLogic.HeroAttributes.CriticalDamageReduction/100;
            var totalDamageReductionFactor = _thisHeroLogic.HeroAttributes.TotalDamageReduction / 100;
            
            var finalCriticalDamage = (1-criticalDamageReductionFactor)*(criticalDamage);

            var floatFinalDamage = (1 - totalDamageReductionFactor) * (normalDamage + finalCriticalDamage);

            var finalDamage = Mathf.FloorToInt(floatFinalDamage);

            return finalDamage;
        }

        //TEST END

        private IEnumerator ApplyFinalDamage(int damageValue)
        {
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
