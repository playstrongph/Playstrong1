using System.Collections;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class InitializeHeroPassiveSkills : MonoBehaviour, IInitializeHeroPassiveSkills
    {
        private IBattleSceneManager _battleSceneManager;
        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }

        public IEnumerator InitPassiveSkills()
        {
            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;
            var mainPlayer = _battleSceneManager.MainPlayer;
            var enemyPlayer = _battleSceneManager.EnemyPlayer;

            var mainHeroObjects = mainPlayer.LivingHeroes.HeroesList;
            var enemyHeroObjects = enemyPlayer.LivingHeroes.HeroesList;

            foreach (var mainHeroObject in mainHeroObjects)
            {
                var mainHero = mainHeroObject.GetComponent<IHero>();
                var heroSkillObjects = mainHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;

                foreach (var heroSkillObject in heroSkillObjects)
                {
                    var heroSkill = heroSkillObject.GetComponent<ISkill>();
                    
                    //TODO SetPassiveSkillHere
                    heroSkill.SkillLogic.InitializePassiveSkill.InitSkill(mainHero, mainHero);
                }
                
            }
            
            foreach (var enemyHeroObject in enemyHeroObjects)
            {
                var enemyHero = enemyHeroObject.GetComponent<IHero>();
                var enemySkillObjects = enemyHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;

                foreach (var enemySkillObject in enemySkillObjects)
                {
                    var enemySkill = enemySkillObject.GetComponent<ISkill>();
                    
                    //TODO SetPassiveSkillHere
                    enemySkill.SkillLogic.InitializePassiveSkill.InitSkill(enemyHero, enemyHero);
                }
                
            }

            logicTree.EndSequence();
            yield return null;
        }

    }
}
