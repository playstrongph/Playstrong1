using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.DamageAttributeMultiple;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DealNonSkillDamage", menuName = "SO's/BasicActions/DealNonSkillDamage")]
    
    public class DealNonSkillDamageBasicActionAsset : BasicActionAsset
    {
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

            logicTree.AddCurrent(DealNonSkillDamage(targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealNonSkillDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Remove this here - transfer it to the skill/status effect asset so that the value is customizable
            //CalculatedValue.SetCalculatedValue(targetHero);

            var nonSkillDamage = Mathf.CeilToInt(CalculatedValue.GetCalculatedValue());

            logicTree.AddCurrent(targetHero.HeroLogic.DealDamageTest.DealNonSkillDamage(targetHero, nonSkillDamage,ignoreArmorChance));

            logicTree.EndSequence();
            yield return null;
        }











    }
}
