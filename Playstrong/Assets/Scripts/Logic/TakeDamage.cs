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
        
        
        //To be Obsoleted
        [SerializeField]
        private int _finalDamage;
        public int FinalDamage => _finalDamage;


        //TEST - Single, Direct, Multiple Damage
        [SerializeField]
        private int _directDamage;
        public int DirectDamage => _directDamage;
        
        [SerializeField]
        private int _singleAttackDamage;
        public int SingleAttackDamage => _singleAttackDamage;
        
        [SerializeField]
        private int _multipleAttackDamage;
        public int MultipleAttackDamage => _multipleAttackDamage;
        

        private void Awake()
        {
            _thisHeroLogic = GetComponent<IHeroLogic>();
        }

        private void Start()
        {
            _logicTree = _thisHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _thisHeroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }
        
        //TODO: Delete After Implem of damageTypes
        //START DELETE
        public IEnumerator TakeAttackDamage(int normalDamage, int criticalDamage, IHero attackerHero)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateChance = attackerHero.HeroLogic.OtherAttributes.PenetrateArmorChance; 
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = penetrateChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);
            
            _finalDamage = ComputeFinalDamage(normalDamage, criticalDamage);
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_finalDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_finalDamage));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }
        private int ComputeFinalDamage(int normalDamage, int criticalDamage)
        {
           
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;

            var floatFinalDamage = (1 - damageReduction) * (normalDamage + criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        
        //DELET END
        
        
        public IEnumerator TakeSingleAttackDamage(int normalDamage, int criticalDamage, IHero attackerHero)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateChance = attackerHero.HeroLogic.OtherAttributes.PenetrateArmorChance; 
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = penetrateChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);

            _singleAttackDamage = ComputeSingleAttackDamage(normalDamage, criticalDamage);
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_singleAttackDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_singleAttackDamage));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator TakeMultipleAttackDamage(int normalDamage, int criticalDamage, IHero attackerHero)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateChance = attackerHero.HeroLogic.OtherAttributes.PenetrateArmorChance; 
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = penetrateChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);
            
            _multipleAttackDamage = ComputeMultipleAttackDamage(normalDamage, criticalDamage);
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_multipleAttackDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_multipleAttackDamage));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator TakeDirectDamage(int directDamage, int criticalDamage, int penetrateChance)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = penetrateChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);

            _directDamage = ComputeDirectDamage(directDamage, criticalDamage);
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_directDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_directDamage));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }

        private int ComputeDirectDamage(int normalDamage, int criticalDamage)
        {
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            var directDamage

            //TODO: Update with directDamageReduction Factor
            var floatFinalDamage = (1 - damageReduction) * (normalDamage + criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        
        private int ComputeSingleAttackDamage(int normalDamage, int criticalDamage)
        {
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;

            //TODO: Update with singleAttackDamage Reduction Factor
            var floatFinalDamage = (1 - damageReduction) * (normalDamage + criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        
        private int ComputeMultipleAttackDamage(int normalDamage, int criticalDamage)
        {
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;

            //TODO: Update with multipleAttackDamage Reduction Factor
            var floatFinalDamage = (1 - damageReduction) * (normalDamage + criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }

        private IEnumerator HeroTakesDamage(int finalDamage)
        {
            //TEMP 
            //TODO: Delete After implem of damageTypes
            _finalDamage = finalDamage;

            //This is where Armor and health gets updated
             ComputeNewArmor(_thisHeroLogic, finalDamage);
             ComputeNewHealth(_thisHeroLogic, _residualDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamageVisual(finalDamage));
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator HeroTakesDamageIgnoreArmor(int finalDamage)
        {
            
            //TEMP 
            //TODO: Delete After implem of damageTypes
            _finalDamage = finalDamage;
            
            //This is where Armor and health gets updated
            ComputeNewHealth(_thisHeroLogic, finalDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamageVisual(finalDamage));
            
            _logicTree.EndSequence();
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
        
        private IEnumerator ApplyFinalDamageVisual(int damageValue)
        {
            var armor = _thisHeroLogic.HeroAttributes.Armor;
            var health = _thisHeroLogic.HeroAttributes.Health;
            
            _thisHeroLogic.Hero.DamageEffect.ShowDamage(damageValue);
            _thisHeroLogic.SetHeroArmor.SetArmor(armor);
            _thisHeroLogic.SetHeroHealth.SetHealth(health);

            _visualTree.EndSequence();
            yield return null;
          
        }

       
        
        


    }
}
