using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseEnergy", menuName = "SO's/BasicActions/IncreaseEnergy")]
    
    public class IncreaseEnergyBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int energyIncrease;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            /*var increaseEnergyChance = targetHero.HeroLogic.OtherAttributes.BoostEnergyChance;
            var increaseEnergyResistance = targetHero.HeroLogic.OtherAttributes.EnergyUpResistance;
            var netBoostChance = increaseEnergyChance - increaseEnergyResistance;
            var randomChance = Random.Range(1, 101);
            if(randomChance<=netBoostChance)*/
                
            //Checking done in SetHeroEnergy Already
            targetHero.HeroLogic.SetHeroEnergy.IncreaseEnergy(energyIncrease);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Increase Energy: " +targetHero.HeroName);
            
            /*var reduceEnergyChance = targetHero.HeroLogic.OtherAttributes.BoostEnergyChance;
            var reduceEnergyResistance = targetHero.HeroLogic.OtherAttributes.EnergyUpResistance;
            var netBoostChance = reduceEnergyChance - reduceEnergyResistance;
            var randomChance = Random.Range(0, 101);
            if(randomChance<=netBoostChance) */
                
            //Checking done in SetHeroEnergy Already
            targetHero.HeroLogic.SetHeroEnergy.IncreaseEnergy(energyIncrease);

            logicTree.EndSequence();
            yield return null;
        }

        /*private void IncreaseEnergy(IHero targetHero, float value)
        {
            var plusEnergy = (int)value;
            targetHero.HeroLogic.SetHeroEnergy.IncreaseEnergy(plusEnergy);
        }*/












    }
}
