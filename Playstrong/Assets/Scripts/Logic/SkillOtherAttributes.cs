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

        [Header("Applied Skill Effects")]
        
        //Factor for overlapping silence effect (e.g. Buff and UniqueEffect)
        //IF silence factor > 0, skill won't be re-enabled
        [SerializeField]
        private int disableSkillEffects = 0;
        public int DisableSkillEffects
        {
            get => disableSkillEffects;
            set => disableSkillEffects = value;
        }
    }
}
