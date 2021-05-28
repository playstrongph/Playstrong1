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
        private List<ISkill> _heroSkills = new List<ISkill>();
        
        private int _index = 0;
        
        private void Awake()
        {
            _panelSkillsObject = GetComponent<IPanelSkills>();
        }
        
        
        //Sets the PanelSkill reference in HeroSkill
        public void ReferenceSkills()
        {
            var heroesSkills = _panelSkillsObject.Player.HeroesSkills;
            var heroesList = heroesSkills.List;
            var panelSkillsList = _panelSkillsObject.List;

            foreach (var skillsPanel in heroesList)
            {
               _panelSkills.Clear();
               _heroSkills.Clear();
               
               GetHeroSkills(heroesList);
               GetPanelSkills(panelSkillsList);

               var index = 0;
               foreach (var skill in _heroSkills)
               {
                   skill.PanelSkill = _panelSkills[index]; 
                   index++;
               }

            }
        }
        
        /// <summary>
        /// Adds each hero skill to a list
        /// </summary>
        private void GetHeroSkills(List<GameObject> heroesList)
        {
            foreach (var skillsPanel in heroesList)
            {
                var skillsObjectList = skillsPanel.GetComponent<ISkillsPanel>().SkillList;

                foreach (var skillObject in skillsObjectList)
                {
                    var skill = skillObject.GetComponent<ISkill>();

                    _heroSkills.Add(skill);

                }

            }
        }

        /// <summary>
        /// Adds each panel skill to a list
        /// </summary>
        private void GetPanelSkills(List<GameObject> panelSkillsList)
        {
            //var panelSkillsList = _panelSkillsObject.List;

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
