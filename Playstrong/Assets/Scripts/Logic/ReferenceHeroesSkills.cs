using System;
using System.Collections.Generic;
using References;
using UnityEngine;

namespace Logic
{
    public class ReferenceHeroesSkills : MonoBehaviour, IReferenceHeroesSkills
    {

        private IPanelSkills _panelSkillsObject;
        private List<ISkill> _panelSkills = new List<ISkill>();
        private int _index = 0;
        
        private void Awake()
        {
            _panelSkillsObject = GetComponent<IPanelSkills>();
        }
        
        
        
        
        //Referencs each hero skill
        public void ReferenceSkills()
        {
         
            GetPanelSkills();
            
            var heroesSkills = _panelSkillsObject.Player.HeroesSkills;
            var heroesList = heroesSkills.List;

            foreach (var skillsPanel in heroesList)
            {
                var skillsObjectList = skillsPanel.GetComponent<ISkillsPanel>().SkillList;

                _index = 0;

                foreach (var skillObject in skillsObjectList)
                {
                    var skill = skillObject.GetComponent<ISkill>();
                    
                    //set the reference of panelSkill here
                    skill.PanelSkill = _panelSkills[_index];
                    _index++;

                }

            }
        }

        /// <summary>
        /// Adds each panel skill to a list
        /// </summary>
        private void GetPanelSkills()
        {
            var panelSkillsList = _panelSkillsObject.List;

            foreach (var heroObject in panelSkillsList)
            {
                var skillsObjectList = heroObject.GetComponent<ISkillsPanel>();

                foreach (var skillObject in skillsObjectList.SkillList)
                {
                    var panelSkill = skillObject.GetComponent<ISkill>();
                    
                    _panelSkills.Add(panelSkill);    
                    
                }
            }
            
        }
    }
}
