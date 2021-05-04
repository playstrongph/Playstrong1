using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CreatePanelSkillReferences : MonoBehaviour, ICreatePanelSkillReferences
    {
        private IHeroesListReference _heroesListReference;
        private IHeroesListReference HeroesListReference => _heroesListReference;

        private int _index;
        private List<GameObject> _panelSkill;

        private void Awake()
        {
            _heroesListReference = GetComponent<IHeroesListReference>();
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
            var panelSkills = HeroesListReference.PanelSkillsList.GetList();
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
            var heroes = HeroesListReference.LivingHeroes.GetList();
          

            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHeroPrefab>();
                var panelSkillsReference = heroObjectReference.PanelSkillsReference;
                
                //set the reference here
                panelSkillsReference.Skills = _panelSkill[_index];
                _index++;
                

            }

            
        }

        
    }
}
