﻿using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Others;
using ScriptableObjects.SkillActions.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillActions
{
    [CreateAssetMenu(fileName = "AddBuffSkillActionAsset", menuName = "SO's/SkillActions/AddBuffSkillActionAsset")]
    
    public class AddBuffSkillActionAsset : SkillActionAsset, IAddBuffSkillActionAsset
    {

        [SerializeField]
        [RequireInterface(typeof(IStatusEffectAsset))]
        private ScriptableObject _buffEffectAsset;
        private IStatusEffectAsset BuffAsset => _buffEffectAsset as IStatusEffectAsset;

        [SerializeField] private int _buffCounters;
        private int BuffCounters => _buffCounters;

        

        public override void Target(IHero hero, ICoroutineTreesAsset coroutineTreesAsset)
        {
           LogicTree = coroutineTreesAsset.MainLogicTree;
            
           LogicTree.AddCurrent(AddBuffCoroutine(hero, coroutineTreesAsset));
           
          

        }

        
        //Multiple Instance AddBuffCoroutine
        private IEnumerator AddBuffCoroutine(IHero hero, ICoroutineTreesAsset coroutineTreesAsset)
        {
            var buffEffectPrefab = hero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = hero.HeroStatusEffects.StatusEffectsPanel.Transform;
            
            var buffEffectObject = Instantiate(buffEffectPrefab, statusEffectPanel);
            buffEffectObject.transform.SetParent(statusEffectPanel);
            var heroStatusEffect = buffEffectObject.GetComponent<IHeroStatusEffect>();
            
            
            heroStatusEffect.CoroutineTreesAsset = coroutineTreesAsset;
            heroStatusEffect.LoadStatusEffectValues.LoadValues(BuffAsset, BuffCounters);
            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect();
           
            
            //Add to respective StatusEffects List in HeroStatusEffects
            heroStatusEffect.StatusEffectType.AddToStatusEffectsList(hero.HeroStatusEffects, heroStatusEffect);
            
            LogicTree.EndSequence();
            yield return null;
        }



    }
}
