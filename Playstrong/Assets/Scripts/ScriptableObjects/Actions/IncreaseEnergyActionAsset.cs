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
        
        public override IEnumerator StartAction(IHero targetHero, float value)
        {
            energyIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newEnergyValue = targetHero.HeroLogic.HeroAttributes.Energy + energyIncrease;
            targetHero.HeroLogic.SetHeroEnergy.SetEnergy(newEnergyValue);
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
