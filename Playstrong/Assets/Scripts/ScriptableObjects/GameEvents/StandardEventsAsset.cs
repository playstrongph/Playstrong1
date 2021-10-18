using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using ScriptableObjects.SkillEffects;
using ScriptableObjects.StandardActions;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.GameEvents
{
    public class StandardEventsAsset : ScriptableObject, IStandardEvent
    {
        
        public void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SubscribeStandardActionCoroutine(hero, standardAction));
        }
        public void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UnsubscribeStandardActionCoroutine(hero,standardAction));
        }
        protected virtual IEnumerator SubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
           var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
           logicTree.EndSequence(); 
           yield return null;
            
        }
        protected virtual IEnumerator UnsubscribeStandardActionCoroutine(IHero hero,IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence(); 
            yield return null;
        }
        
        
        public void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SubscribeStandardActionCoroutine(skill, standardAction));
        }
        public void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UnsubscribeStandardActionCoroutine(skill,standardAction));
        }
        protected virtual IEnumerator SubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
            
        }
        protected virtual IEnumerator UnsubscribeStandardActionCoroutine(ISkill skill,IStandardActionAsset standardAction)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
            
        }

        //STATUS EFFECT COUNTERS UPDATE
        public void SubscribeStatusEffectCountersUpdate(IHeroStatusEffect statusEffect)
        {
            var logicTree = statusEffect.StatusEffectCasterHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SubscribeStatusEffectCountersUpdateCoroutine(statusEffect));
        }
        public void UnsubscribeStatusEffectCountersUpdate(IHeroStatusEffect statusEffect)
        {
            var logicTree = statusEffect.StatusEffectCasterHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UnsubscribeStatusEffectCountersUpdateCoroutine(statusEffect));
        }
        protected virtual IEnumerator SubscribeStatusEffectCountersUpdateCoroutine(IHeroStatusEffect statusEffect)
        {
            var logicTree = statusEffect.StatusEffectCasterHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
            
        }
        protected virtual IEnumerator UnsubscribeStatusEffectCountersUpdateCoroutine(IHeroStatusEffect statusEffect)
        {
            var logicTree = statusEffect.StatusEffectCasterHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
            
        }
        
        
        //TEST - SkillEffectAsset StartAction
        public void SubscribeStandardAction(IHero hero, ISkillEffectAsset skillEffect)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SubscribeStandardActionCoroutine(hero, skillEffect));
        }
        public void UnsubscribeStandardAction(IHero hero, ISkillEffectAsset skillEffect)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UnsubscribeStandardActionCoroutine(hero,skillEffect));
        }
        protected virtual IEnumerator SubscribeStandardActionCoroutine(IHero hero, ISkillEffectAsset skillEffect)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence(); 
            yield return null;
            
        }
        protected virtual IEnumerator UnsubscribeStandardActionCoroutine(IHero hero, ISkillEffectAsset skillEffect)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence(); 
            yield return null;
        }
        
        public void SubscribeStandardAction(ISkill skill, ISkillEffectAsset skillEffect)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SubscribeStandardActionCoroutine(skill, skillEffect));
        }
        public void UnsubscribeStandardAction(ISkill skill, ISkillEffectAsset skillEffect)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UnsubscribeStandardActionCoroutine(skill,skillEffect));
        }
        protected virtual IEnumerator SubscribeStandardActionCoroutine(ISkill skill, ISkillEffectAsset skillEffect)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
            
        }
        protected virtual IEnumerator UnsubscribeStandardActionCoroutine(ISkill skill, ISkillEffectAsset skillEffect)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
            
        }
        
        
        


    }
}
