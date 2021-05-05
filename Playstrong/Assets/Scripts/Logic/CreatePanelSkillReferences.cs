using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CreatePanelSkillReferences : MonoBehaviour, ICreatePanelSkillReferences
    {
        private IPlayerChildrenReferences _playerChildrenReferences;
        private IPlayerChildrenReferences PlayerChildrenReferences => _playerChildrenReferences;

        private int _index;
        private List<GameObject> _panelSkill;

        private void Awake()
        {
            _playerChildrenReferences = GetComponent<IPlayerChildrenReferences>();
            _index = 0;
            _panelSkill = new List<GameObject>();
        }

        public IEnumerator CreateReferences(ICoroutineTree tree)
        {
            GetSkillReference();
            LoadSkillReference();
            yield return null;
            tree.EndSequence();
        }

        
        /// <summary>
        /// Player level reference source of HeroSkills
        /// </summary>
        private void GetSkillReference()
        {
            var panelSkills = PlayerChildrenReferences.PanelSkillsList.GetList();
            foreach (var skill in panelSkills)
            {
                _panelSkill.Add(skill);
                

            }
            
        }
        
        /// <summary>
        /// Sets the Hero Level reference for the Player's HeroSkills
        /// </summary>
        
        private void LoadSkillReference()
        {
            var heroes = PlayerChildrenReferences.LivingHeroes.GetList();
          

            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHeroPrefab>();
                var panelSkillsReference = heroObjectReference.PanelHeroSkills;
                
                //set the reference here
                panelSkillsReference.Skills = _panelSkill[_index];
                _index++;
                

            }

            
        }

        
    }
}
