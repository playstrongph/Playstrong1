using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DealSkillDamage", menuName = "SO's/BasicActions/D/DealSkillDamage")]
    
    public class DealSkillDamageBasicActionAsset : BasicActionAsset
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

            logicTree.AddCurrent(DealSkillDamage(targetHero,targetHero));

            logicTree.EndSequence();
            yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            Debug.Log("TargetHero: " +targetHero.HeroName);
            Debug.Log("Deal Skill Damage to: " +targetHero.HeroName);
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealSkillDamage(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealSkillDamage(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Remove this here - transfer it to the skill/status effect asset so that the value is customizable
            //CalculatedValue.OtherHeroBasis = targetHero;
            var nonSkillDamage = Mathf.CeilToInt(CalculatedValue.GetCalculatedValue() +flatDamageValue);

            logicTree.AddCurrent(targetHero.HeroLogic.DealDamageTest.DealNonAttackSkillDamage(thisHero, targetHero, nonSkillDamage,ignoreArmorChance));

            logicTree.EndSequence();
            yield return null;
        }
        
       










    }
}
