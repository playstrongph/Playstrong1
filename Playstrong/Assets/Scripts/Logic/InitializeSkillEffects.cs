using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class InitializeSkillEffects : MonoBehaviour, IInitializeSkillEffects
    {
        private ITurnController _turnController;
        private ITurnController TurnController => _turnController;

        private ICoroutineTree _logicTree;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

        public IEnumerator InitAllSkills()
        {
            _logicTree = _turnController.BattleSceneManager.LogicTree;
            
            InitAllySkills();
            InitEnemySkills();

            _logicTree.EndSequence();
            yield return null;
        }

        private void InitAllySkills()
        {
            //Skills Panel for each heroes
            var skillPanelObjects = _turnController.BattleSceneManager.MainPlayer.HeroesSkills.List;
            foreach (var skillPanelObject in skillPanelObjects)
            {
                //Skills  of each hero
                var skillObjects = skillPanelObject.GetComponent<ISkillsPanel>().SkillList;

                foreach (var skillObject in skillObjects)
                {
                    var skill = skillObject.GetComponent<ISkill>();
                    var hero = skill.Hero;
                    
                    skill.SkillLogic.SkillAttributes.SkillEffect.RegisterSkillEffect(hero, hero, skill);
                    
                    
                }
                
            }
        }
        
        private void InitEnemySkills()
        {
            //Skills Panel for each heroes
            var skillPanelObjects = _turnController.BattleSceneManager.EnemyPlayer.HeroesSkills.List;
            foreach (var skillPanelObject in skillPanelObjects)
            {
                //Skills  of each hero
                var skillObjects = skillPanelObject.GetComponent<ISkillsPanel>().SkillList;

                foreach (var skillObject in skillObjects)
                {
                    var skill = skillObject.GetComponent<ISkill>();
                    var hero = skill.Hero;
                    
                    skill.SkillLogic.SkillAttributes.SkillEffect.RegisterSkillEffect(hero, hero, skill);
                    
                    
                }
                
            }
        }







    }
}
