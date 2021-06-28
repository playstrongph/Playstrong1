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
        
        

        private void Awake()
        {
            _thisHeroLogic = GetComponent<IHeroLogic>();
           
        }

        private void Start()
        {
            _logicTree = _thisHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _thisHeroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }

        public IEnumerator DamageHero(int damageValue)
        {
            _targetArmor = _thisHeroLogic.HeroAttributes.Armor;
            _targetHealth = _thisHeroLogic.HeroAttributes.Health;

            var finalDamage = ComputeFinalDamage(damageValue);

            var residualDamage = DamageTargetArmor(_targetArmor, finalDamage);
            DamageTargetHealth(_targetHealth, residualDamage);
            
            _visualTree.AddCurrent(VisualDamageHero(finalDamage));

            yield return null;
            _logicTree.EndSequence();
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

        private IEnumerator VisualDamageHero(int damageValue)
        {
            _thisHeroLogic.Hero.DamageEffect.ShowDamage(damageValue);
            
            _thisHeroLogic.Hero.HeroVisual.ArmorVisual.SetArmorText(_targetArmor);
            
            _thisHeroLogic.Hero.HeroVisual.HealthVisual.SetHealthText(_targetHealth.ToString());

            yield return null;
            _visualTree.EndSequence();
        }

        private int DamageTargetArmor(int armor, int damage)
        {
            var residualDamage = damage-armor;
            residualDamage = Mathf.Clamp(residualDamage, 0, armor + damage);

            var newArmor = armor - damage;
            newArmor = Mathf.Clamp(newArmor, 0, armor + damage);
            _targetArmor = newArmor;
            _thisHeroLogic.HeroAttributes.Armor = newArmor;

            return residualDamage;
        }
        
        private void DamageTargetHealth(int health, int damage)
        {
            var newHealth = health - damage;
            //newHealth = Mathf.Clamp(newHealth, 0, health + damage);
            _targetHealth = newHealth;
            _thisHeroLogic.HeroAttributes.Health = newHealth;

        }


    }
}
