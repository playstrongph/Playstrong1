using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class ReduceSkillCooldown : MonoBehaviour
    {
        private ISkillLogic _skillLogic;
        private ISkillAttributes _skillAttributes;

        private delegate void SkillCdAction(int counter);
        private List<SkillCdAction> _skillCdAction = new List<SkillCdAction>();
       
        private int _actionIndex = 0;
        public int ActionIndex
        {
            set => _actionIndex = value;
        }

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
            _skillAttributes = _skillLogic.SkillAttributes;
            
            _skillCdAction.Add(ReduceCdAction);
            _skillCdAction.Add(DoNothing);
        }
        
        //Convert to IEnumerator
        public void ReduceCd(int counter)
        {
            _skillCdAction[_actionIndex](counter);
        }

        private void ReduceCdAction(int counter)
        {
            var skillCd = _skillAttributes.Cooldown;
            var maxSkillCd = _skillAttributes.BaseCooldown;
            
            skillCd -= counter;
            //Note: Multiplier of 10(exaggerated) used to allow CD to go beyond max Skill CD.
            skillCd = Mathf.Clamp(skillCd, 0, maxSkillCd * 10);

            _skillAttributes.Cooldown = skillCd;

        }

        private void DoNothing(int counter)
        {
            
        }


    }
}
