using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class TakeDamageTest : MonoBehaviour, ITakeDamageTest
    {
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IHeroLogic _thisHeroLogic;
        private int _residualDamage;
        
        
        //To be Obsoleted
        [SerializeField]
        private int finalDamage;
        public int FinalDamage => finalDamage;


        //TEST - Single, Direct, Multiple Damage
        //To be Obsoleted
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
        
        public IEnumerator TakeSingleAttackDamage(int nonCriticalDamage, int criticalDamage, IHero attackerHero)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateChance = attackerHero.HeroLogic.OtherAttributes.PenetrateArmorChance; 
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = penetrateChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);

            _singleAttackDamage = ComputeSingleAttackDamage(nonCriticalDamage, criticalDamage);
            
            //For use of methods that doesn't care about damage types - e.g. Reflect
            finalDamage = _singleAttackDamage;

            _logicTree.AddCurrent(BeforeHeroTakesSkillDamage(targetHero));
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_singleAttackDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_singleAttackDamage));

            _logicTree.AddCurrent(AfterHeroTakesSkillDamage(targetHero));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator TakeMultiAttackDamage(int nonCriticalDamage, int criticalDamage, IHero attackerHero)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateChance = attackerHero.HeroLogic.OtherAttributes.PenetrateArmorChance; 
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = penetrateChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);
            
            _multipleAttackDamage = ComputeMultipleAttackDamage(nonCriticalDamage, criticalDamage);
            
            //For use of methods that doesn't care about damage types - e.g. Reflect
            finalDamage = _multipleAttackDamage;
            
            _logicTree.AddCurrent(BeforeHeroTakesSkillDamage(targetHero));
            
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_multipleAttackDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_multipleAttackDamage));
            
            _logicTree.AddCurrent(AfterHeroTakesSkillDamage(targetHero));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }
        
        
        //TODO: Review Need for this
        public IEnumerator TakeDirectDamage(int nonCriticalDamage, int criticalDamage, int ignoreArmorChance)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = ignoreArmorChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);

            _directDamage = ComputeDirectDamage(nonCriticalDamage, criticalDamage);
            
            //For use of methods that doesn't care about damage types - e.g. Reflect
            finalDamage = _directDamage;
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_directDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_directDamage));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For non-attack damage abilities in skills.  Example - whenever you are attacked, deal 5 damage to your attacker.
        /// </summary>
        public IEnumerator TakeNonAttackSkillDamage(int nonAttackDamage,float ignoreArmorChance)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = ignoreArmorChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);

            _directDamage = ComputeDirectDamage(nonAttackDamage, 0);
            
            //For use of methods that doesn't care about damage types - e.g. Reflect
            finalDamage = _directDamage;
            
            _logicTree.AddCurrent(BeforeHeroTakesSkillDamage(targetHero));
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_directDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_directDamage));
            
            _logicTree.AddCurrent(AfterHeroTakesSkillDamage(targetHero));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For non-skill damage sources such as status effects and weapons
        /// </summary>
        public IEnumerator TakeNonSkillDamage(int nonAttackDamage,float ignoreArmorChance)
        {
            var targetHero = _thisHeroLogic.Hero;
            var penetrateResistance = targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance;
            var netChance = ignoreArmorChance - penetrateResistance;
            var randomChance = Random.Range(1, 101);

            _directDamage = ComputeDirectDamage(nonAttackDamage, 0);
            
            //For use of methods that doesn't care about damage types - e.g. Reflect
            finalDamage = _directDamage;
            
            _logicTree.AddCurrent(BeforeHeroTakesNonSkillDamage(targetHero));
            
            if(randomChance <=netChance)
                _logicTree.AddCurrent(HeroTakesDamageIgnoreArmor(_directDamage));
            else
                _logicTree.AddCurrent(HeroTakesDamage(_directDamage));
            
            _logicTree.AddCurrent(AfterHeroTakesNonSkillDamage(targetHero));

            _logicTree.AddCurrent(_thisHeroLogic.HeroDies.CheckHeroDeath(targetHero));

            _logicTree.EndSequence();
            yield return null;
        }


        //AUXILLIARY METHODS
        private int ComputeDirectDamage(int nonCriticalDamage, int criticalDamage)
        {
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            var directDamageReduction = _thisHeroLogic.OtherAttributes.DirectDamageReduction / 100;

            var floatFinalDamage =(1-directDamageReduction)* (1 - damageReduction) * (nonCriticalDamage + criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        
        private int ComputeSingleAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            var singleAttackDamageReduction = _thisHeroLogic.OtherAttributes.SingleAttackDamageReduction / 100;

            //TODO: Update with singleAttackDamage Reduction Factor
            var floatFinalDamage = (1-singleAttackDamageReduction)*(1 - damageReduction) * (nonCriticalDamage + criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        
        private int ComputeMultipleAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var damageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            var multipleAttackDamageReduction = _thisHeroLogic.OtherAttributes.MultipleAttackDamageReduction / 100;
            
            //TODO: Update with multipleAttackDamage Reduction Factor
            var floatFinalDamage = (1-multipleAttackDamageReduction)*(1 - damageReduction) * (nonCriticalDamage + criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }

        private IEnumerator HeroTakesDamage(int finalDamage)
        {
            //This is where Armor and health gets updated
             ComputeNewArmor(_thisHeroLogic, finalDamage);
             ComputeNewHealth(_thisHeroLogic, _residualDamage);
            
            _visualTree.AddCurrent(ApplyFinalDamageVisual(finalDamage));
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator HeroTakesDamageIgnoreArmor(int finalDamage)
        {
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

       
        //EVENTS
        private IEnumerator BeforeHeroTakesSkillDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.HeroEvents.BeforeHeroTakesSkillDamage(targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        private IEnumerator AfterHeroTakesSkillDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.HeroEvents.AfterHeroTakesSkillDamage(targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator BeforeHeroTakesNonSkillDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.HeroEvents.BeforeHeroTakesNonSkillDamage(targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator AfterHeroTakesNonSkillDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.HeroEvents.AfterHeroTakesNonSkillDamage(targetHero);

            logicTree.EndSequence();
            yield return null;
        }


    }
}
