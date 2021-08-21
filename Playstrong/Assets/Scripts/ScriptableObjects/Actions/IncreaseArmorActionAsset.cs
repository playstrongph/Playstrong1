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
    [CreateAssetMenu(fileName = "IncreaseArmor", menuName = "SO's/SkillActions/IncreaseArmor")]
    
    public class IncreaseArmorActionAsset : SkillActionAsset
    {
        [SerializeField] private int armorIncrease;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            armorIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newArmorValue = targetHero.HeroLogic.HeroAttributes.Armor + armorIncrease;
            targetHero.HeroLogic.SetHeroArmor.SetArmor(newArmorValue);

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
