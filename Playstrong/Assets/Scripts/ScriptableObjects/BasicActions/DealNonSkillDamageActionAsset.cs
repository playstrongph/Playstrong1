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
        public ICalculatedValueAsset CalculatedValue => calculatedValue as ICalculatedValueAsset;

        public override IEnumerator TargetAction(IHero dummyHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealNonSkillDamage(targetHero,targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealNonSkillDamage(IHero dummyHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var nonCriticalDamage = Mathf.CeilToInt(CalculatedValue.GetCalculatedValue());
            
            //Status-Effects Do not Deal Critical Strike
            var criticalDamage = 0;
            
            //TEST
            //TODO: NonSkillDamage no attackerHero arg
            //targetHero.HeroLogic.DealDamageTest.DealNonSkillDamage(targetHero,targetHero,nonCriticalDamage,criticalDamage);

            logicTree.EndSequence();
            yield return null;
        }











    }
}
