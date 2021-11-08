using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "ConsumeAllFightingSpirit", menuName = "SO's/BasicActions/C/ConsumeAllFightingSpirit")]
    
    public class ConsumeAllFightingSpiritBasicActionAsset : BasicActionAsset
    {
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newFightingSpiritValue = 0;
            
            targetHero.HeroLogic.SetHeroFightingSpirit.SetFightingSpirit(newFightingSpiritValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newFightingSpiritValue = 0;
            
            targetHero.HeroLogic.SetHeroFightingSpirit.SetFightingSpirit(newFightingSpiritValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        

      

      










    }
}
