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
        
        

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealDirectDamage(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealDirectDamage(IHero thisHero, IHero targetHero )
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //logicTree.AddCurrent(thisHero.HeroLogic.DealDamage.DealDirectDamage(targetHero, reflectDamage));
            
            logicTree.EndSequence();
            yield return null;
        }











    }
}
