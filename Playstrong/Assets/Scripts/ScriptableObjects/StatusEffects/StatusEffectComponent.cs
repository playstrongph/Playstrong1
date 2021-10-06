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
    public class StatusEffectComponent : MonoBehaviour
    {
        [SerializeField] private ScriptableObject statusEffectAsset;

        public IStatusEffectAsset StatusEffectAsset
        {
            get => statusEffectAsset as IStatusEffectAsset;
            set => statusEffectAsset = value as ScriptableObject;
        }
        
        [SerializeField]
        private List<ScriptableObject> standardActionAssets = new List<ScriptableObject>();

        public List<IStandardActionAsset> StandardActionAssets
        {
            get
            {
                var standardActions = new List<IStandardActionAsset>();
                foreach (var standardActionAssetObject in standardActionAssets)
                {
                    var standardAction = standardActionAssetObject as IStandardActionAsset;
                    standardActions.Add(standardAction);
                }
                return standardActions;
            }
        }
        
        [SerializeField]
        private List<ScriptableObject> actionTargetAssets = new List<ScriptableObject>();

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



    }
}
