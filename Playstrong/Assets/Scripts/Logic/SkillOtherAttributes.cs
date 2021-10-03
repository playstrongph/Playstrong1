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

        [Header("Skill Factors")]
        
        //Factor for overlapping silence effect (e.g. Buff and UniqueEffect)
        //IF silence factor > 0, skill won't be re-enabled
        [SerializeField]
        private int silenceFactor = 0;
        public int SilenceFactor
        {
            get => silenceFactor;
            set => silenceFactor = value;
        }
    }
}
