﻿using System.Collections;
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
                hero.HeroLogic.HeroEvents.EStartOfGame += skillCondition.Target;
            }
            
            LogicTree.EndSequence();  
            yield return null;
        }


    }
}