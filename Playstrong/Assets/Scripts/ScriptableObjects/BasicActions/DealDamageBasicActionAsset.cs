using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.DamageAttributeMultiple;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
   
    
    //Damage enemy based on ally hero attribute
    [CreateAssetMenu(fileName = "DealDamage", menuName = "SO's/BasicActions/DealDamage")]
    
    public class DealDamageBasicActionAsset : BasicActionAsset
    {
        
        [SerializeField] private int flatDamageValue;

        [SerializeField] private ScriptableObject calculatedDamageValue;
        private ICalculatedValueAsset CalculatedDamageValue => calculatedDamageValue as ICalculatedValueAsset;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealDirectDamage(targetHero));

            logicTree.EndSequence();
            yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealDirectDamage(targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealDirectDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var damageValue = ComputeTotalDamage(targetHero);

            logicTree.AddCurrent(targetHero.HeroLogic.DealDamage.DealDirectDamage(targetHero, damageValue));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        
        
        

        private int ComputeTotalDamage(IHero hero)
        {
            var calculatedValue = Mathf.CeilToInt(CalculatedDamageValue.GetCalculatedValue());
            var totalDamage = flatDamageValue + calculatedValue;
            
            return totalDamage;
        }











    }
}
