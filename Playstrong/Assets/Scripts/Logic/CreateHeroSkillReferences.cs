using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CreateHeroSkillReferences : MonoBehaviour, ICreateHeroSkillReferences
    {
        private IPlayer _player;
        private IPlayer Player => _player;

        private int _index;
        private List<GameObject> _heroSkill;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
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
            var heroSkills = Player.HeroesSkills.List;
            foreach (var skill in heroSkills)
            {
                _heroSkill.Add(skill);
            }
        }
        
        private void LoadSkillReference()
        {
            var heroes = Player.LivingHeroes.HeroesList;
          

            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHero>();
                var skillsReference = heroObjectReference.Skills;
                
                //set the reference here
                skillsReference.Skills = _heroSkill[_index];
                _index++;

            }
        }

        
    }
}
