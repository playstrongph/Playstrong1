using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DealNonSkillDamage", menuName = "SO's/BasicActions/D/DealNonSkillDamage")]
    
    public class DealNonSkillDamageBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatDamageValue;
        
        [SerializeField]
        private ScriptableObject calculatedValue;
        private ICalculatedFactorValueAsset CalculatedValue => calculatedValue as ICalculatedFactorValueAsset;

        [SerializeField]
        private float ignoreArmorChance = 0;

        public override IEnumerator TargetAction(IHero targetHero)
        {
           
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealNonSkillDamage(targetHero));

            logicTree.EndSequence();
            yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            Debug.Log("TargetHero: " +targetHero.HeroName);
            Debug.Log("Deal NonSkill Damage to: " +targetHero.HeroName);
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealNonSkillDamage(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealNonSkillDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Remove this here - transfer it to the skill/status effect asset so that the value is customizable
            //CalculatedValue.OtherHeroBasis = targetHero;
            var nonSkillDamage = Mathf.CeilToInt(CalculatedValue.GetCalculatedValue() +flatDamageValue);

            logicTree.AddCurrent(targetHero.HeroLogic.DealDamageTest.DealNonSkillDamage(targetHero, nonSkillDamage,ignoreArmorChance));

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator DealNonSkillDamage(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Remove this here - transfer it to the skill/status effect asset so that the value is customizable
            //CalculatedValue.OtherHeroBasis = targetHero;
            var nonSkillDamage = Mathf.CeilToInt(CalculatedValue.GetCalculatedValue()+flatDamageValue);

            logicTree.AddCurrent(targetHero.HeroLogic.DealDamageTest.DealNonSkillDamage(targetHero, nonSkillDamage,ignoreArmorChance));

            logicTree.EndSequence();
            yield return null;
        }











    }
}
