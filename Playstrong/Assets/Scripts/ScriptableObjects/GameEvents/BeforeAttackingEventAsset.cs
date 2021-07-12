using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.GameEvents
{
    [CreateAssetMenu(fileName = "BeforeAttacking", menuName = "SO's/GameEvents/BeforeAttackingGE")]
    public class BeforeAttackingEventAsset : GameEvents
    {
        protected override IEnumerator SubscribeToEventCoroutine(IHero hero)
        {
            
            
            var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
                hero.HeroLogic.HeroEvents.EBeforeAttacking += skillCondition.Target;
            }
            
            LogicTree.EndSequence();  
            yield return null;
        }


    }
}
