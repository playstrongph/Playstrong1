using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "DecreasePenetrateResistance", menuName = "SO's/SkillActions/DecreasePenetrateResistance")]
    
    public class DecreasePenetrateResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int penetrateResistance ;

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            penetrateResistance = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.PenetrateArmorResistance -= penetrateResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
