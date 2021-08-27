using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAttackActionAsset", menuName = "SO's/SkillActions/IncreaseAttackActionAsset")]
    
    public class IncreaseAttackActionAsset : SkillActionAsset
    {
        [SerializeField] private int attackIncrease;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            attackIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + attackIncrease;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
