using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class InitializePassiveSkill : MonoBehaviour, IInitializePassiveSkill
    {
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

        public void InitSkill(IHero thisHero, IHero targetHero)
        {
            var targetSkill = _skillLogic.Skill.TargetSkill;
            _skillLogic.SkillAttributes.SkillType.UsePassiveSkill(targetSkill, thisHero, targetHero);
        }
    }
}
