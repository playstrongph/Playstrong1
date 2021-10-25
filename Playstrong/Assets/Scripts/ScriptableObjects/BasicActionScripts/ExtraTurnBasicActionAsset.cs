using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "ExtraTurnBasicAction", menuName = "SO's/BasicActions/ExtraTurnBasicAction")]
    
    public class ExtraTurnBasicActionAsset : BasicActionAsset
    {

        [SerializeField] private ScriptableObject actionTarget;
        private IActionTargets ActionTarget => actionTarget as IActionTargets;
        
        //Need to set exaggeratedly big
        private int extraTurnEnergyValue = 10000;
        
        public override IEnumerator TargetAction(IHero hero)
        {
           var logicTree = hero.CoroutineTreesAsset.MainLogicTree;

           var extraTurnHero = ActionTarget.GetHeroTarget(hero);
           
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
            
            var extraTurnHero = ActionTarget.GetHeroTarget(thisHero,targetHero);
            
            //Set Hero Energy
            SetHeroEnergyMax(extraTurnHero);

            //Add to active heroes
            UpdateActiveHeroesList(extraTurnHero);

            logicTree.EndSequence();
            yield return null;
        }

        private void SetHeroEnergyMax(IHero hero)
        {
            hero.HeroLogic.SetHeroEnergy.SetEnergy(extraTurnEnergyValue);
        }

        private void UpdateActiveHeroesList(IHero hero)
        {
            var turnController = hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroTimer = hero.HeroLogic.HeroTimer as Object;
            turnController.ActiveHeroes.Add(heroTimer);
        }








    }
}
