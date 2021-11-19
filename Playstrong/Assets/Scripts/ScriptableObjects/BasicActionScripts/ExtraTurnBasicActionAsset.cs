using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "ExtraTurnBasicAction", menuName = "SO's/BasicActions/E/ExtraTurnBasicAction")]
    
    public class ExtraTurnBasicActionAsset : BasicActionAsset
    {

        /*[SerializeField] private ScriptableObject actionTarget;
        private IActionTargets ActionTarget => actionTarget as IActionTargets;*/
        
        //Need to set exaggeratedly big
        private int extraTurnEnergyValue = 10000;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

           //var extraTurnHero = ActionTarget.GetHeroTarget(hero);
           
           //TEST
           var extraTurnHero = targetHero;
           
           
           //Set Hero Energy
           SetHeroEnergyMax(extraTurnHero);

           //Add to active heroes
           UpdateActiveHeroesList(extraTurnHero);
           
           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TEST
            //var extraTurnHero = ActionTarget.GetHeroTarget(thisHero,targetHero);

            var extraTurnHero = targetHero;
            
            //Set Hero Energy
            SetHeroEnergyMax(extraTurnHero);

            //Add to active heroes
            UpdateActiveHeroesList(extraTurnHero);

            logicTree.EndSequence();
            yield return null;
        }

        private void SetHeroEnergyMax(IHero targetHero)
        {
           Debug.Log("Extra Turn: " +targetHero.HeroName);
           targetHero.HeroLogic.SetHeroEnergy.SetEnergy(extraTurnEnergyValue);
        }

        private void UpdateActiveHeroesList(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var turnController = targetHero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroTimer = targetHero.HeroLogic.HeroTimer as Object;
            
            
            turnController.ActiveHeroes.Add(heroTimer);
            
            //test
            logicTree.AddCurrent(turnController.SortHeroesByEnergy.SortByEnergy());
        }








    }
}
