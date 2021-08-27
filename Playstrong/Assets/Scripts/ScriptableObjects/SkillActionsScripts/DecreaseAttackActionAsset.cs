using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
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
