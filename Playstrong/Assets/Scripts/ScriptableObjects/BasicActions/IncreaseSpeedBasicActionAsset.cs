using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseSpeedBasicAction", menuName = "SO's/BasicActions/IncreaseSpeedBasicAction")]
    
    public class IncreaseSpeedBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int speedIncrease;

       
        public override IEnumerator TargetAction(IHero targetHero, float value)
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
