using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
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
