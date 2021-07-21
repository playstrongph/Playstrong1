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

        public ISkillAttributes SkillAttributes { get; set; }
      

        public void RegisterSkillEffect(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(RegisterSkillEffectCoroutine(skill));
           
        }
        
        
        /// <summary>
        /// This is only used to subscribe to SKillTarget Event
        /// </summary>
        private IEnumerator RegisterSkillEffectCoroutine(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;

            SkillEffectEvent.SubscribeToSkillEvents(skill);

            SkillEffectEvent.SkillAttributes = SkillAttributes;
           
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public void RegisterSkillEffect(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(RegisterSkillEffectCoroutine(thisHero));
        }
        
        private IEnumerator RegisterSkillEffectCoroutine(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;

            SkillEffectEvent.SubscribeToHeroEvents(thisHero);

            SkillEffectEvent.SkillAttributes = SkillAttributes;

            logicTree.EndSequence();
            yield return null;
        }

       






    }
}
