using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.GameEvents
{
    [CreateAssetMenu(fileName = "StartOfGame", menuName = "SO's/GameEvents/StartOfGameGE")]
    public class StartOfGameEventAsset : GameEvents
    {
        protected override IEnumerator SubscribeToHeroEventsCoroutine(IHero hero)
        {
            var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
                hero.HeroLogic.HeroEvents.EStartOfGame += skillCondition.UseSkillAction;
            }
            
            LogicTree.EndSequence();  
            yield return null;
        }
        
        protected override IEnumerator UnsubscribeToHeroEventsCoroutine(IHero hero)
        {
            var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
                hero.HeroLogic.HeroEvents.EStartOfGame -= skillCondition.UseSkillAction;
            }
            
            LogicTree.EndSequence();  
            yield return null;
        }


    }
}
