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
    [CreateAssetMenu(fileName = "DecreaseAttackActionAsset", menuName = "SO's/SkillActions/DecreaseAttackActionAsset")]
    
    public class DecreaseAttackActionAsset : SkillActionAsset
    {
        [SerializeField] private int attackDecrease;
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            attackDecrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack - attackDecrease;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
