using System;
using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class GetAllHeroSkills : MonoBehaviour, IGetAllHeroSkills
    {
        private List<ISkill> heroSkills = new List<ISkill>();

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public List<ISkill> HeroSkills(IHero hero)
        {
            var skillObjects = hero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            heroSkills.Clear();
            foreach (var skillObject in skillObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                heroSkills.Add(skill);
            }
            return heroSkills;
        }
        
    }
}
