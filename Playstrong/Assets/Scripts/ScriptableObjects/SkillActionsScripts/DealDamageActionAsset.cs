using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DealDamage", menuName = "SO's/SkillActions/DealDamage")]
    
    public class DealDamageActionAsset : SkillActionAsset
    {
        [SerializeField]
        private int penetrateChance;

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(DealDirectDamage(targetHero, value));

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator DealDirectDamage(IHero targetHero, float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var intValue = (int) value;
            
            logicTree.AddCurrent(targetHero.HeroLogic.DealDamage.DealDirectDamage(targetHero, intValue));
            
            logicTree.EndSequence();
            yield return null;
        }











    }
}
