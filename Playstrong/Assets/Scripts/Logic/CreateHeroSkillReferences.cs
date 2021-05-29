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
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            _index = 0;
            _heroSkill = new List<GameObject>();
        }
        
        private void Start()
        {
            _logicTree = _player.GlobalTrees.MainLogicTree;
            _visualTree = _player.GlobalTrees.MainVisualTree;
        }

        public IEnumerator CreateReferences()
        {
            GetSkillReference();
            LoadSkillAndHeroReference();
            yield return null;
            _logicTree.EndSequence();
        }


        private void GetSkillReference()
        {
            var heroSkills = Player.HeroesSkills.List;
            foreach (var skill in heroSkills)
            {
                _heroSkill.Add(skill);
            }
        }
        
        private void LoadSkillAndHeroReference()
        {
            var heroes = Player.LivingHeroes.HeroesList;
            
            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHero>();
                
                var skillsReference = heroObjectReference.HeroSkills;
                
                //set the references here
                skillsReference.Skills = _heroSkill[_index];
                _heroSkill[_index].GetComponent<ISkillsPanel>().Hero = heroObjectReference;
                _index++;

            }
        }

        
    }
}
