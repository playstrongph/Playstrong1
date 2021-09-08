using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseEnergy", menuName = "SO's/SkillActions/DecreaseEnergy")]
    
    public class DecreaseEnergyActionAsset : SkillActionAsset
    {
        [SerializeField] private int energyDecrease;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            energyDecrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var reduceEnergyChance = targetHero.HeroLogic.OtherAttributes.BoostEnergyChance;
            var reduceEnergyResistance = targetHero.HeroLogic.OtherAttributes.BoostEnergyResistance;
            var netBoostChance = reduceEnergyChance - reduceEnergyResistance;
            var randomChance = Random.Range(0, 101);

            if(randomChance<=netBoostChance)
                DecreaseEnergy(targetHero, value);

            logicTree.EndSequence();
            yield return null;
        }

        private void DecreaseEnergy(IHero targetHero, float value)
        {
            var minusEnergy = (int)value;
            targetHero.HeroLogic.SetHeroEnergy.DecreaseEnergy(minusEnergy);
        }












    }
}
