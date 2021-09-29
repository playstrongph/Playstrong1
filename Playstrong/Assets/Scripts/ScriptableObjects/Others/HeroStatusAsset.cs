using System.Collections;
using Interfaces;
using Logic;
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
        

    }
}
