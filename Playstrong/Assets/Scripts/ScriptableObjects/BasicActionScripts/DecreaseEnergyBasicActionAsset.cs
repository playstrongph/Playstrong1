using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseEnergy", menuName = "SO's/BasicActions/D/DecreaseEnergy")]
    
    public class DecreaseEnergyBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int energyDecrease;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
           
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var reduceEnergyChance = targetHero.HeroLogic.OtherAttributes.BoostEnergyChance;
            var reduceEnergyResistance = targetHero.HeroLogic.OtherAttributes.EnergyUpResistance;
            var netBoostChance = reduceEnergyChance - reduceEnergyResistance;
            var randomChance = Random.Range(0, 101);

            if(randomChance<=netBoostChance)
                DecreaseEnergy(targetHero, energyDecrease);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var reduceEnergyChance = targetHero.HeroLogic.OtherAttributes.BoostEnergyChance;
            var reduceEnergyResistance = targetHero.HeroLogic.OtherAttributes.EnergyUpResistance;
            var netBoostChance = reduceEnergyChance - reduceEnergyResistance;
            var randomChance = Random.Range(0, 101);

            if(randomChance<=netBoostChance)
                DecreaseEnergy(targetHero, energyDecrease);

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
