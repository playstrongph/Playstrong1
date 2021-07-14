using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.GameEvents;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace ScriptableObjects.SkillEffects
{
   
    [CreateAssetMenu(fileName = "SkillEffectAsset", menuName = "SO's/SkillEffect/SkillEffectAsset")]
    public class SkillEffectAsset : ScriptableObject, ISkillEffectAsset
    {
        
        [SerializeField] [RequireInterface(typeof(IGameEvents))]
        private Object _skilEffectEvent;
        private IGameEvents SkillEffectEvent => _skilEffectEvent as IGameEvents;


        
        public void RegisterSkillEffect(IHero thisHero, IHero targetHero, ISkill skill)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(RegisterSkillEffectCoroutine(thisHero, targetHero, skill));
        }
        
        
        
        private IEnumerator RegisterSkillEffectCoroutine(IHero thisHero, IHero targetHero, ISkill skill)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            SkillEffectEvent.SubscribeToHeroEvents(thisHero);
            SkillEffectEvent.SubscribeToSkillEvents(skill);
            
            logicTree.EndSequence();
            yield return null;
        }






    }
}
