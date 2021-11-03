using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseDebuffChance", menuName = "SO's/BasicActions/DecreaseDebuffChance")]
    
    public class DecreaseDebuffChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int debuffChance;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            Debug.Log("Decrease Debuff Chance");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffChance -= debuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Decrease Debuff Chance");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffChance -= debuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffChance += debuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffChance += debuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
