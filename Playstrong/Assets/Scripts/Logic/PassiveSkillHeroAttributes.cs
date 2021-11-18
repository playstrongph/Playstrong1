using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class PassiveSkillHeroAttributes : MonoBehaviour, IPassiveSkillHeroAttributes
    {
        [Header("BASIC HERO ATTRIBUTES")]
        [SerializeField] private int attack;
        public int Attack
        {
            get => attack;
            set => attack = value;
        }

        [SerializeField] private int speed;
        public int Speed
        {
            get => speed;
            set => speed = value;
        }

        [SerializeField] private int chance;
        public int Chance
        {
            get => chance;
            set => chance = value;
        }
        
        
        [Header("OTHER HERO CHANCE ATTRIBUTES")]
        [SerializeField] private int counterAttackChance;
        public int CounterAttackChance
        {
            get => counterAttackChance;
            set => counterAttackChance = value;
        }
        
        [SerializeField] private int criticalStrikeChance;
        public int CriticalStrikeChance
        {
            get => criticalStrikeChance;
            set => criticalStrikeChance = value;
        }
        
        [SerializeField] private int skillChanceBonus;
        public int SkillChanceBonus
        {
            get => skillChanceBonus;
            set => skillChanceBonus = value;
        }
        
        
        
        [Header("OTHER HERO RESISTANCE ATTRIBUTES")]
        [SerializeField] private int criticalStrikeResistance;
        public int CriticalStrikeResistance
        {
            get => criticalStrikeResistance;
            set => criticalStrikeResistance = value;
        }
        
        [SerializeField] private int debuffResistance;
        public int DebuffResistance
        {
            get => debuffResistance;
            set => debuffResistance = value;
        }
        
        [SerializeField] private int attackTargetResistance;
        public int AttackTargetResistance
        {
            get => attackTargetResistance;
            set => attackTargetResistance = value;
        }
        
        
        [Header("OTHER HERO DAMAGE MULTIPLIERS")]
        [SerializeField] private int criticalDamageMultiplier;
        public int CriticalDamageMultiplier
        {
            get => criticalDamageMultiplier;
            set => criticalDamageMultiplier = value;
        }

        //References
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        //Called during SEAL and other passive skill silence effects
        public IEnumerator DisablePassiveAttributes()
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            var heroAttributes = _heroLogic.HeroAttributes;
            var otherHeroAttributes = _heroLogic.OtherAttributes;

            //Attack
            var newAttackValue = heroAttributes.Attack - Attack;
            _heroLogic.SetHeroAttack.SetAttack(newAttackValue);
            
            //Speed
            var newSpeedValue = heroAttributes.Speed - Speed;
            _heroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);
            
           //Chance
           heroAttributes.Chance -= Chance;
           
           //CounterAttackChance
           otherHeroAttributes.CounterAttackChance -= CounterAttackChance;
           
           //CriticalStrikeChance
           otherHeroAttributes.CriticalStrikeChance -= CriticalStrikeChance;
           
           //SkillChanceBonus
           otherHeroAttributes.SkillChanceBonus -= SkillChanceBonus;
           
           //CriticalStrikeResistance
           otherHeroAttributes.CriticalStrikeResistance -= CriticalStrikeResistance;
           
           //DebuffResistance
           otherHeroAttributes.DebuffResistance -= DebuffResistance;
           
           //AttackTargetResistance
           otherHeroAttributes.AttackTargetResistance -= AttackTargetResistance;
           
           //CriticalDamage Multiplier
           otherHeroAttributes.CriticalDamageMultiplier -= CriticalDamageMultiplier;

           logicTree.EndSequence();
           yield return null;
        }
        
        //Called after removing SEAL and other passive skill silence effects
        public IEnumerator EnablePassiveAttributes()
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            var heroAttributes = _heroLogic.HeroAttributes;
            var otherHeroAttributes = _heroLogic.OtherAttributes;

            //Attack
            var newAttackValue = heroAttributes.Attack + Attack;
            _heroLogic.SetHeroAttack.SetAttack(newAttackValue);
            
            //Speed
            var newSpeedValue = heroAttributes.Speed + Speed;
            _heroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);
            
            //Chance
            heroAttributes.Chance += Chance;
           
            //CounterAttackChance
            otherHeroAttributes.CounterAttackChance += CounterAttackChance;
           
            //CriticalStrikeChance
            otherHeroAttributes.CriticalStrikeChance += CriticalStrikeChance;
            
            //SkillChanceBonus
            otherHeroAttributes.SkillChanceBonus += SkillChanceBonus;
           
            //CriticalStrikeResistance
            otherHeroAttributes.CriticalStrikeResistance += CriticalStrikeResistance;
           
            //DebuffResistance
            otherHeroAttributes.DebuffResistance += DebuffResistance;
           
            //AttackTargetResistance
            otherHeroAttributes.AttackTargetResistance += AttackTargetResistance;
           
            //CriticalDamage Multiplier
            otherHeroAttributes.CriticalDamageMultiplier += CriticalDamageMultiplier;

            logicTree.EndSequence();
            yield return null;
        }

        
        
        
    }
}
