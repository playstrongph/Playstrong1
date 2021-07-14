using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class CreateHeroSkillReferences : MonoBehaviour, ICreateHeroSkillReferences
    {
        private IPlayer _player;
        private IPlayer Player => _player;

        private int _index;
        private List<GameObject> _playerHeroesSkillsList = new List<GameObject>();
        private List<GameObject> _heroSkillsList = new List<GameObject>();
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            _index = 0;
           
        }
        
        private void Start()
        {
            _logicTree = _player.GlobalTrees.MainLogicTree;
            _visualTree = _player.GlobalTrees.MainVisualTree;
        }

        public IEnumerator CreateReferences()
        {
            GetSkillReference();
            LoadSkillPanelAndHeroReference();
            yield return null;
            _logicTree.EndSequence();
        }


        private void GetSkillReference()
        {
            var heroSkills = Player.HeroesSkills.List;
            foreach (var skill in heroSkills)
            {
                _playerHeroesSkillsList.Add(skill);
            }
        }
        
        private void LoadSkillPanelAndHeroReference()
        {
            var heroObjects = Player.LivingHeroes.HeroesList;
            
            foreach (var heroObject in heroObjects)
            {
                var hero = heroObject.GetComponent<IHero>();

                //set the references here
                hero.HeroSkills.Skills = _playerHeroesSkillsList[_index];
                
                var heroSkillsList = hero.HeroSkills.Skills;
                
                LoadSkillHeroReference(heroSkillsList, hero);

                _index++;

            }
        }

        private void LoadSkillHeroReference(GameObject heroSkillsList, IHero hero)
        {
            var skillsObjectList = heroSkillsList.GetComponent<ISkillsPanel>().SkillList;
            
            foreach (var skillObject in skillsObjectList)
            {
                var skill = skillObject.GetComponent<ISkill>();
                skill.Hero = hero;
            }
        }
        
        


    }
}
