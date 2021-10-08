using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.StandardActions;
using ScriptableObjects.StatusEffects.Instance;
using ScriptableObjects.StatusEffects.StatusEffectCounter;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace ScriptableObjects.StatusEffects
{
    public class StatusEffectComponent : MonoBehaviour, IStatusEffectComponent
    {
        [SerializeField] private ScriptableObject statusEffectAsset;

        public IStatusEffectAsset StatusEffectAsset
        {
            get => statusEffectAsset as IStatusEffectAsset;
            set => statusEffectAsset = value as ScriptableObject;
        }
        
        
        [SerializeField]
        private List<ScriptableObject> standardActionObjectAssets = new List<ScriptableObject>();
        //To make it assignable in script 
        //Remove this if List is exclusively assigned via Inspector
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

        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
        }
        
        
        
        
        
        
    }
}
