using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseDebuffChance", menuName = "SO's/BasicActions/I/IncreaseDebuffChance")]
    
    public class IncreaseDebuffChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int debuffChance;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            Debug.Log("Increase Debuff Chance");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffChance += debuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Increase Debuff Chance");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffChance += debuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffChance -= debuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffChance -= debuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
