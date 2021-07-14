using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.GameEvents
{
    [CreateAssetMenu(fileName = "DragBasicAttack", menuName = "SO's/GameEvents/DragBasicAttack")]
    public class DragBasicAttackEventAsset : GameEvents
    {
        protected override IEnumerator SubscribeToHeroEventsCoroutine(IHero hero)
        {
            //Index = 0;
            
            var skillConditions = SkillConditionAssets;
            foreach (var skillCondition in skillConditions)
            {
                //hero.HeroLogic.HeroEvents.EDragBasicAttack += SkillConditionTarget;
                hero.HeroLogic.HeroEvents.EDragBasicAttack += skillCondition.Target;
                
                //Index++;
                Debug.Log("EDragBasicAttack Subscribe");
            }
            
            LogicTree.EndSequence();  
            yield return null;
        }


    }
}
