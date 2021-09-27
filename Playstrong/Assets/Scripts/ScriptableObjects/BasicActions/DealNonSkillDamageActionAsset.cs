using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.DamageAttributeMultiple;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DealDamage", menuName = "SO's/SkillActions/DealDamage")]
    
    public class DealNonSkillDamageBasicActionAsset : BasicActionAsset
    {
        [SerializeField]
        private ScriptableObject calculatedValue;
        private ICalculatedValueAsset CalculatedValue => calculatedValue as ICalculatedValueAsset;

        [SerializeField]
        private float ignoreArmorChance = 0;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealNonSkillDamage(targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealNonSkillDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var nonSkillDamage = Mathf.CeilToInt(CalculatedValue.GetCalculatedValue());

            targetHero.HeroLogic.DealDamageTest.DealNonSkillDamage(targetHero, nonSkillDamage,ignoreArmorChance);

            logicTree.EndSequence();
            yield return null;
        }











    }
}
