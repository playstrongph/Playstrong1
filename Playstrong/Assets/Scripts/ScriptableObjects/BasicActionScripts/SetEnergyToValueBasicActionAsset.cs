using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "SetEnergyToValue", menuName = "SO's/BasicActions/S/SetEnergyToValue")]
    
    public class SetEnergyToValueBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatEnergyValue;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            Debug.Log("SetEnergyToValue: " +targetHero.HeroName);
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var currentEnergy = targetHero.HeroLogic.HeroAttributes.Energy;
            
            if(currentEnergy < flatEnergyValue)
                IncreaseEnergy(targetHero);
            else
                targetHero.HeroLogic.SetHeroEnergy.SetEnergy(flatEnergyValue);

            logicTree.EndSequence();
            yield return null;
        }

        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //Do Nothing
            
            logicTree.EndSequence();
            yield return null;
        }


        private void IncreaseEnergy(IHero targetHero)
        {
           
            var boostEnergyChance = targetHero.HeroLogic.OtherAttributes.BoostEnergyChance;
            var boostEnergyResistance = targetHero.HeroLogic.OtherAttributes.EnergyUpResistance;
            var netBoostChance = boostEnergyChance - boostEnergyResistance;
            var randomChance = Random.Range(0, 101);

            if(randomChance<=netBoostChance)
                targetHero.HeroLogic.SetHeroEnergy.SetEnergy(flatEnergyValue);
        }
















    }
}
