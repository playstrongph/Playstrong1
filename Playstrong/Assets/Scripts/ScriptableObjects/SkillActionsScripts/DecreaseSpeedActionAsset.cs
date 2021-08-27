using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseSpeedAction", menuName = "SO's/SkillActions/DecreaseSpeedAction")]
    
    public class DecreaseSpeedActionAsset : SkillActionAsset
    {
        [SerializeField] private int speedDecrease;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            speedDecrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newSpeedValue = targetHero.HeroLogic.HeroAttributes.Speed - speedDecrease;
            targetHero.HeroLogic.SetHeroSpeed.SetSpeed(newSpeedValue);

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
