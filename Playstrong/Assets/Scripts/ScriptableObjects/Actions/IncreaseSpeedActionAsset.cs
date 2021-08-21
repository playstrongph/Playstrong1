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
    [CreateAssetMenu(fileName = "IncreaseSpeedActionAsset", menuName = "SO's/SkillActions/IncreaseSpeedActionAsset")]
    
    public class IncreaseSpeedActionAsset : SkillActionAsset
    {
        [SerializeField] private int speedIncrease;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            speedIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newSpeedValue = targetHero.HeroLogic.HeroAttributes.Speed + speedIncrease;
            targetHero.HeroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
