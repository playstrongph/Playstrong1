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
