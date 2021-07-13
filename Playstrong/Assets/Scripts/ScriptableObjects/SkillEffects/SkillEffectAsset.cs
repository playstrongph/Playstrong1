using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
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


        //TODO:  Call this after setting skill effect in skill attributes
        public void UseSkillEffect(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(UseSkillEffectCoroutine(thisHero, targetHero));
        }
        
        
        //TODO:  Change this to events instead of conditions

        private IEnumerator UseSkillEffectCoroutine(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            SkillEffectEvent.SubscribeToEvent(thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }






    }
}
