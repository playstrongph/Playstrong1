using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAttackBasicAction", menuName = "SO's/BasicActions/IncreaseAttack")]
    
    public class IncreaseAttackBasicActionAsset : BasicActionAsset
    {

        public override IEnumerator TargetAction(IHero targetHero,float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var attackIncrease = Mathf.CeilToInt(value * targetHero.HeroLogic.HeroAttributes.Attack / 100);
                                 

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + attackIncrease;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
