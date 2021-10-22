using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseArmor", menuName = "SO's/BasicActions/IncreaseArmor")]
    
    public class IncreaseArmorBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatArmor;
        
        [SerializeField] private ScriptableObject armorFactor;
        private ICalculatedFactorValueAsset ArmorFactor => armorFactor as ICalculatedFactorValueAsset;

        

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var percentArmor = (int) ArmorFactor.GetCalculatedValue();
            var newArmorValue = targetHero.HeroLogic.HeroAttributes.Armor + flatArmor + percentArmor;
            
            targetHero.HeroLogic.SetHeroArmor.SetArmor(newArmorValue);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var percentArmor = (int) ArmorFactor.GetCalculatedValue();
            var newArmorValue = targetHero.HeroLogic.HeroAttributes.Armor + flatArmor + percentArmor;
            
            targetHero.HeroLogic.SetHeroArmor.SetArmor(newArmorValue);
            
            logicTree.EndSequence();
            yield return null;
        }


       

      










    }
}
