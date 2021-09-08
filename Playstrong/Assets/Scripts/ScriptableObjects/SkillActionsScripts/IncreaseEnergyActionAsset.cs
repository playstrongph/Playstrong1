using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseEnergy", menuName = "SO's/SkillActions/IncreaseEnergy")]
    
    public class IncreaseEnergyActionAsset : SkillActionAsset
    {
        [SerializeField] private int energyIncrease;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            energyIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var boostEnergyChance = targetHero.HeroLogic.OtherAttributes.BoostEnergyChance;
            var boostEnergyResistance = targetHero.HeroLogic.OtherAttributes.BoostEnergyResistance;
            var netBoostChance = boostEnergyChance - boostEnergyResistance;
            var randomChance = Random.Range(0, 101);

            if(randomChance<=netBoostChance)
                IncreaseEnergy(targetHero, value);

            logicTree.EndSequence();
            yield return null;
        }

        private void IncreaseEnergy(IHero targetHero, float value)
        {
            var plusEnergy = (int)value;
            targetHero.HeroLogic.SetHeroEnergy.IncreaseEnergy(plusEnergy);
        }












    }
}
