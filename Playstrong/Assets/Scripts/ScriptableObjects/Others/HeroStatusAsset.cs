using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Others
{
    [CreateAssetMenu(fileName = "Hero Status", menuName = "SO's/Hero Status")]
    public class HeroStatusAsset : ScriptableObject, IHeroStatusAsset
    {
        public virtual void InitializeTurnController(ITurnController turnController)
        {
            
        }

        public virtual void StatusAction(IHeroLogic heroLogic)
        {
            
        }

        public virtual void RemoveFromActiveHeroesList(ITurnController turnController, Object heroTimer)
        {
            turnController.ActiveHeroes.Remove(heroTimer);
        }
        
        public virtual IEnumerator EndHeroTurn(IHeroLogic heroLogic)
        {
            var logicTree = heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            var turnController = heroLogic.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            
            turnController.EndCombatTurn();
            
            //Debug.Log("Hero Active End Hero Turn");

            logicTree.EndSequence();
            yield return null;
        }
        
        
        //NEW TEST - Nov 11 2021
        public virtual IEnumerator HeroUsingSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Hero Inactive Using Skill");

            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator HeroUsedSkillLastTurn(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            

            logicTree.EndSequence();
            yield return null;
        }

    }
}
