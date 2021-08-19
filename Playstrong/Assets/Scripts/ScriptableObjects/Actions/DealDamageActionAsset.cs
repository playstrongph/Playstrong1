using System.Collections;
using DG.Tweening;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;
using UnityEngine.Accessibility;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "DealDamage", menuName = "SO's/SkillActions/DealDamage")]
    
    public class DealDamageActionAsset : SkillActionAsset
    {
        private int _finalAttackValue;
        
        

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealDirectDamage(targetHero, value));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealDirectDamage(IHero targetHero, float value )
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var intValue = (int) value;
            
            logicTree.AddCurrent(targetHero.HeroLogic.DealDamage.DealDirectDamage(targetHero, intValue));
            
            logicTree.EndSequence();
            yield return null;
        }











    }
}
