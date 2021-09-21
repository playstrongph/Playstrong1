using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DealDamage", menuName = "SO's/BasicActions/DealDamage")]
    
    public class DealDamageBasicActionAsset : BasicActionAsset
    {
        
        [SerializeField] private int flatDamageValue;
        
        //For now, this will be a lot
        [SerializeField] private int percentDamageValue;
        
        //e.g. - health, speed, damage taken, etc.
        //multiplied to percentDamageValue
        //TODO: CreateIHeroAttributeMultiple
        //Below should no be int
        [SerializeField] private int heroAttributeMultiple;
     

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealDirectDamage(targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealDirectDamage(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var damageValue = -ComputeTotalDamage(targetHero);
         
            logicTree.AddCurrent(targetHero.HeroLogic.DealDamage.DealDirectDamage(targetHero, damageValue));
            
            logicTree.EndSequence();
            yield return null;
        }

        private int ComputeTotalDamage(IHero hero)
        {
            var percentDamage = Mathf.CeilToInt(percentDamageValue * heroAttributeMultiple / 100);
            var totalDamage = flatDamageValue + percentDamage;
            return totalDamage;
        }











    }
}
