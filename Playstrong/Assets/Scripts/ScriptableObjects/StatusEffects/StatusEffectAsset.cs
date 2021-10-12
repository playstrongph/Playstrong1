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
    public class StatusEffectAsset : ScriptableObject, IStatusEffectAsset
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [TextArea(1,2)]
        [SerializeField] private string _description;
        public string Description => _description;

        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;

        [SerializeField] 
        [RequireInterface(typeof(IStatusEffectType))]
        private ScriptableObject _statusEffectType;
        
        public IStatusEffectType StatusEffectType => _statusEffectType as IStatusEffectType;

        [SerializeField] [RequireInterface(typeof(IStatusEffectCounterUpdate))]
        private ScriptableObject updateTiming;
        public IStatusEffectCounterUpdate UpdateTiming => updateTiming as IStatusEffectCounterUpdate;

        [SerializeField] [RequireInterface(typeof(IStatusEffectInstance))]
        private ScriptableObject _statusEffectInstance;
        public IStatusEffectInstance StatusEffectInstance => _statusEffectInstance as IStatusEffectInstance;
        //Used by stacking skill effects
        [SerializeField] private int maxSkillCounters = 1 ;
        public int MaxSkillCounters => maxSkillCounters;

        [SerializeField] private List<ScriptableObject> _standardActions;
        public List<ScriptableObject> StandardActionsObjects => _standardActions;
        public List<IStandardActionAsset> StandardActions
        {
            get
            {
                var newStandardActions = new List<IStandardActionAsset>();
                foreach (var standarActionObject in _standardActions)
                {
                    var standardAction = standarActionObject as IStandardActionAsset;
                    newStandardActions.Add(standardAction);
                }

                return newStandardActions;
            }
        }

        
        public virtual void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardAction in StandardActions)
            {
                logicTree.AddCurrent(standardAction.RegisterStandardAction(hero));
            }
        }

        public virtual void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardAction in StandardActions)
            {
                logicTree.AddCurrent(standardAction.UnregisterStandardAction(hero));
            }
        }

        public virtual void ApplyStackingEffect(IHero hero)
        {
        }

        public virtual void UnapplyStackingEffect(IHero hero)
        {
        }
        
        //Used by Resurrect and Extinction - as they need to persist post death
        public virtual void RemoveStatusEffectOnDeath(IHero hero, IHeroStatusEffect statusEffect)
        {
            statusEffect.RemoveStatusEffect.RemoveEffect(hero);
        }

      




    }
}
