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

        
        /// <summary>
        /// If there are skills or other modifiers that change the multiplier of critical factor
        /// to a float other than 2, then "Add" it to the list;
        /// </summary>
        [SerializeField] private List<float> criticalFactor = new List<float>();
        public List<float> CriticalFactor => criticalFactor;
        
        /// <summary>
        /// This is a list of other possible attack modifiers that are 'unique' - i.e.
        /// they only have 1 value and could not vary
        /// </summary>
        [SerializeField] private List<int> uniqueAttackModifiers;
        public List<int> FinalAttackModifiers => uniqueAttackModifiers;
        
        /// <summary>
        /// This returns the greatest value from the possible critical factors
        /// inside the critical list
        /// </summary>
        public float GetCriticalFactor()
        {
            var maxValue = Mathf.Max(FinalAttackModifiers.ToArray());
            return maxValue;
        }


    }
}
