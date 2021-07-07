using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using DG.Tweening;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BasicAttack : MonoBehaviour, IBasicAttack
    {

        [SerializeField]
        [RequireInterface(typeof(IHeroAction))]
        private Object _attackAction;
        public IHeroAction AttackAction => _attackAction as IHeroAction;

        [SerializeField] private float criticalMultiplier;

        public float CriticalMultiplier
        {
            get => criticalMultiplier;
            set => criticalMultiplier = value;
        }
        
        /// <summary>
        /// Default value is 1 (No Critical Strike).  Status Effects and Skills will "Add" to this list
        /// the respective critical strike multiplier they provide, which is typically the defaultCritical
        /// factor
        /// </summary>
        [SerializeField] private List<float> criticalMultipliers = new List<float>();
        public List<float> CriticalMultipliers => criticalMultipliers;
        
        /// <summary>
        /// This is a list of other possible attack modifiers that are 'unique' - i.e.
        /// they only have 1 value and could not vary. Default setting is a value of 1.
        /// </summary>
        [SerializeField] private List<float> uniqueAttackModifiers;
        public List<float> UniqueAttackModifiers => uniqueAttackModifiers;
        
        /// <summary>
        /// This returns the greatest value from the possible critical factors
        /// inside the critical list
        /// </summary>
        public float GetCriticalFactor()
        {
            var maxValue = Mathf.Max(UniqueAttackModifiers.ToArray());
            return maxValue;
        }


    }
}
