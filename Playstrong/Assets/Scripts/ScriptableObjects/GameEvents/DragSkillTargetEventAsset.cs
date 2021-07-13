using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.GameEvents
{
    [CreateAssetMenu(fileName = "DragSkillTarget", menuName = "SO's/GameEvents/DragSkillTarget")]
    public class DragSkillTargetEventAsset : GameEvents
    {
        protected override IEnumerator SubscribeToEventCoroutine(IHero hero)
        {
            var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
           
                hero.HeroLogic.HeroEvents.EDragSkillTarget += skillCondition.Target;
                
           
                Debug.Log("EDragSkillTarget Subscribe");
            }
            
            LogicTree.EndSequence();  
            yield return null;
        }


    }
}
