using System.Collections;
using System.Collections.Generic;
using Interfaces;
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

        private int _targetArmor;
        private int _targetHealth;
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
            _targetArmor = _thisHeroLogic.HeroAttributes.Armor;
            _targetHealth = _thisHeroLogic.HeroAttributes.Health;

            var finalDamage = ComputeFinalDamage(damageValue);
            
            //TEST - feedback to attack for actual damage he dealt
            attacker.HeroLogic.DealDamage.FinalDamageDealt = finalDamage;
            Debug.Log(attacker.HeroName+"-Final Damage Dealt: " +attacker.HeroLogic.DealDamage.FinalDamageDealt);
            //TEST END

            ComputeNewArmor(_targetArmor, finalDamage);
            ComputeNewHealth(_targetHealth, _residualDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamage(finalDamage));

            yield return null;
            _logicTree.EndSequence();
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

        private IEnumerator ApplyFinalDamage(int damageValue)
        {
            _thisHeroLogic.Hero.DamageEffect.ShowDamage(damageValue);
            
            _thisHeroLogic.SetHeroArmor.SetArmor(_targetArmor);
            _thisHeroLogic.SetHeroHealth.SetHealth(_targetHealth);

            yield return null;
            _visualTree.EndSequence();
        }

        private void ComputeNewArmor(int armor, int damage)
        {
            _residualDamage = damage-armor;
            _residualDamage = Mathf.Clamp(_residualDamage, 0, armor + damage);

            var newArmor = armor - damage;
            newArmor = Mathf.Clamp(newArmor, 0, armor + damage);
            
            _targetArmor = newArmor;
            
        }
        
        private void ComputeNewHealth(int health, int damage)
        {
            var newHealth = health - damage;
            _targetHealth = newHealth;
        }

       
        
        


    }
}
