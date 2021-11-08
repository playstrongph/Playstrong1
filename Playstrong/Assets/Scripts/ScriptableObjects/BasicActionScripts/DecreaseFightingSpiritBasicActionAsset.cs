using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseFightingSpirit", menuName = "SO's/BasicActions/D/DecreaseFightingSpirit")]
    
    public class DecreaseFightingSpiritBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatFightingSpirit;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newFightingSpiritValue = targetHero.HeroLogic.OtherAttributes.FightingSpirit - flatFightingSpirit;
            
            targetHero.HeroLogic.SetHeroFightingSpirit.SetFightingSpirit(newFightingSpiritValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newFightingSpiritValue = targetHero.HeroLogic.OtherAttributes.FightingSpirit - flatFightingSpirit;
            
            targetHero.HeroLogic.SetHeroFightingSpirit.SetFightingSpirit(newFightingSpiritValue);
            
            Debug.Log("targetHero: " +targetHero.HeroName +" FightingSpirit: " +newFightingSpiritValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            //No Actionk 

            logicTree.EndSequence();
            yield return null;
        }


      

      










    }
}
