using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.GameEvents
{
    [CreateAssetMenu(fileName = "BeforeAttacking", menuName = "SO's/GameEvents/BeforeAttackingGE")]
    public class BeforeAttackingGE : GameEvents
    {
        protected override IEnumerator SubscribeToEventCoroutine(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EBeforeAttacking += SkillConditionTarget;
            
            LogicTree.EndSequence();  
            yield return null;
        }


    }
}
