using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class PassiveSkillHeroAttributes : MonoBehaviour
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
      




    }
}
