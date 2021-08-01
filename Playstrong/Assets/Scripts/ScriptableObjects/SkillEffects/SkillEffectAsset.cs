using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Enums.SkillStatus;
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


        public void RegisterSkillEffect(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(RegisterSkillEffectCoroutine(skill));
           
        }
        
        public void RegisterSkillEffect(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(RegisterSkillEffectCoroutine(thisHero));
        }
        
        public void UnregisterSkillEffect(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(UnregisterSkillEffectCoroutine(skill));
           
        }
        
        public void UnregisterSkillEffect(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(UnregisterSkillEffectCoroutine(thisHero));
        }


        /// <summary>
        /// This is only used to subscribe to SKillTarget Event
        /// </summary>
        private IEnumerator RegisterSkillEffectCoroutine(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;

            SkillEffectEvent.SubscribeToSkillEvents(skill);

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator RegisterSkillEffectCoroutine(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            SkillEffectEvent.SubscribeToHeroEvents(thisHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator UnregisterSkillEffectCoroutine(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;

            SkillEffectEvent.UnsubscribeToSkillEvents(skill);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator UnregisterSkillEffectCoroutine(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            SkillEffectEvent.UnsubscribeToHeroEvents(thisHero);

            logicTree.EndSequence();
            yield return null;
        }

       






    }
}
