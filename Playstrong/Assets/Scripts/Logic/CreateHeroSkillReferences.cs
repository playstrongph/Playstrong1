using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CreateHeroSkillReferences : MonoBehaviour, ICreateHeroSkillReferences
    {
        private IHeroesListReference _heroesListReference;
        private IHeroesListReference HeroesListReference => _heroesListReference;

        private int _index;
        private List<GameObject> _heroSkill;

        private void Awake()
        {
            _heroesListReference = GetComponent<IHeroesListReference>();
            _index = 0;
            _heroSkill = new List<GameObject>();
        }

        public IEnumerator CreateReferences(ICoroutineTree tree)
        {
            GetSkillReference();
            LoadSkillReference();
            yield return null;
            tree.EndSequence();
        }


        private void GetSkillReference()
        {
            var heroSkills = HeroesListReference.HeroSkillsList.GetList();
            foreach (var skill in heroSkills)
            {
                _heroSkill.Add(skill);
            }
        }
        
        private void LoadSkillReference()
        {
            var heroes = HeroesListReference.LivingHeroes.GetList();
          

            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHeroPrefab>();
                var skillsReference = heroObjectReference.Skills;
                
                //set the reference here
                skillsReference.Skills = _heroSkill[_index];
                _index++;

            }
        }

        
    }
}
