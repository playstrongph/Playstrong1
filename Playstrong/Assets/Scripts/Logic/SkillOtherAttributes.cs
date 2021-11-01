using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class SkillOtherAttributes : MonoBehaviour, ISkillOtherAttributes
    {

        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }


        [Header("APPLIED SKILL EFFECTS")]
        //Factor for overlapping silence effect (e.g. Buff and UniqueEffect)
        //IF silence factor > 0, skill won't be re-enabled
        [SerializeField]
        private int disableSkillEffects = 0;
        public int DisableSkillEffects
        {
            get => disableSkillEffects;
            set => disableSkillEffects = value;
        }
        
        
        /// <summary>
        /// Used for tracking hero attribute effects provided by skills
        /// usually with limits (e.g. Ravi's demon's blood)
        /// </summary>
        [SerializeField] private int skillCounters;
        public int SkillCounters
        {
            get => skillCounters;
            set => skillCounters = value;
        }


        [Header("SKILL CHANCE")] [SerializeField]
        private int _criticalChance;

        public int CriticalChance
        {
            get => _criticalChance;
            set => _criticalChance = value;
        }
        
        [Header("SKILL RESISTANCE")] [SerializeField]
        private int _criticalResistance;

        public int CriticalResistance
        {
            get => _criticalResistance;
            set => _criticalResistance = value;
        }



    }
}
