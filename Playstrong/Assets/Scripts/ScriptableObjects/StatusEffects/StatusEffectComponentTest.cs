using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.ActionTargets;
using ScriptableObjects.StandardActions;
using ScriptableObjects.StatusEffects.Instance;
using ScriptableObjects.StatusEffects.StatusEffectCounter;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace ScriptableObjects.StatusEffects
{
    public class StatusEffectComponentTest : MonoBehaviour, IStatusEffectComponent
    {
        [SerializeField] private ScriptableObject statusEffectAsset;
        public ScriptableObject statusEffectAssetObject => statusEffectAsset;
        public IStatusEffectAsset StatusEffectAsset
        {
            get => statusEffectAsset as IStatusEffectAsset;
            set => statusEffectAsset = value as ScriptableObject;
        }
        
        
        [SerializeField]
        private List<ScriptableObject> standardActionObjectAssets = new List<ScriptableObject>();
        public List<ScriptableObject> StandardActionObjectAssets => standardActionObjectAssets;
        public List<IStandardActionAsset> StandardActionAssets
        {
            get
            {
                var standardActions = new List<IStandardActionAsset>();
                foreach (var standardActionObject in standardActionObjectAssets)
                {
                    var standardAction = standardActionObject as IStandardActionAsset;
                    standardActions.Add(standardAction);
                }

                return standardActions;
            }
        }
        
        [SerializeField]
        private List<ScriptableObject> actionTargetAssets = new List<ScriptableObject>();
        public List<ScriptableObject> ActionTargetObjectAssets => actionTargetAssets;
        public List<IActionTargets> ActionTargetAssets
        {
            get
            {
                var actionTargets = new List<IActionTargets>();
                foreach (var actionTargetObject in actionTargetAssets)
                {
                    var actionTarget = actionTargetObject as IActionTargets;
                    actionTargets.Add(actionTarget);
                }
                return actionTargets;
            }
        }

        private IHeroStatusEffect _heroStatusEffect;
        
        //TEST
        public IHero StatusEffectCasterHero { get; set; }
        public IHero StatusEffectTargetHero { get; set; }


        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
        }

        public void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardActionAsset in StandardActionAssets)
            {
                logicTree.AddCurrent(standardActionAsset.RegisterStandardAction(hero));
            }
        }
        
        public void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardActionAsset in StandardActionAssets)
            {
                logicTree.AddCurrent(standardActionAsset.UnregisterStandardAction(hero));
            }
        }
        
        public virtual void RemoveStatusEffectOnDeath(IHero hero, IHeroStatusEffect statusEffect)
        {
            statusEffect.RemoveStatusEffect.RemoveEffect(hero);
        }
        
        
        








    }
}
