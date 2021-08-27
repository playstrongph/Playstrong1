using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
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
