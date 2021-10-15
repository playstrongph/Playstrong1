﻿using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "SetEnergyToValue", menuName = "SO's/BasicActions/SetEnergyToValue")]
    
    public class SetEnergyToValueBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int energyValue;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var currentEnergy = targetHero.HeroLogic.HeroAttributes.Energy;
            
            if(currentEnergy < energyValue)
                IncreaseEnergy(targetHero);
            else
                targetHero.HeroLogic.SetHeroEnergy.SetEnergy(energyValue);

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
                targetHero.HeroLogic.SetHeroEnergy.SetEnergy(energyValue);
        }
















    }
}
