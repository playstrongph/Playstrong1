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


        private int extraTurnEnergyValue = 10000;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           
           targetHero.HeroLogic.SetHeroEnergy.SetEnergy(extraTurnEnergyValue);
           
           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO - make this assignable to either target Hero or This Hero
            thisHero.HeroLogic.SetHeroEnergy.SetEnergy(extraTurnEnergyValue);

            var turnController = thisHero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroTimer = thisHero.HeroLogic.HeroTimer as Object;
            
            turnController.ActiveHeroes.Add(heroTimer);

            Debug.Log("Extra Turn: " +thisHero.HeroName);
           
            logicTree.EndSequence();
            yield return null;
        }

       



      


    }
}
