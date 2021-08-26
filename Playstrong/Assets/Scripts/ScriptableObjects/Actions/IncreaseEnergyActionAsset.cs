using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
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
            var newEnergyValue = targetHero.HeroLogic.HeroAttributes.Energy + energyIncrease;
            targetHero.HeroLogic.SetHeroEnergy.SetEnergy(newEnergyValue);
        }












    }
}
