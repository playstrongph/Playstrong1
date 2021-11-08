using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreasePenetrateArmorResistance", menuName = "SO's/BasicActions/D/DecreasePenetrateArmorResistance")]
    
    public class DecreasePenetrateArmorResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int penetrateArmorResistance ;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance -= penetrateArmorResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance += penetrateArmorResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
