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
    public class UniqueEffectAsset : ScriptableObject, IUniqueEffectAsset
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [TextArea(1,2)]
        [SerializeField] private string _description;
        public string Description => _description;

        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;

        //NA to UniqueEffects
        /*[SerializeField] 
        [RequireInterface(typeof(IStatusEffectType))]
        private ScriptableObject _statusEffectType;        
        public IStatusEffectType StatusEffectType => _statusEffectType as IStatusEffectType;*/

        //TODO: Create UpdateTiming for UniqueEffects
        [SerializeField] [RequireInterface(typeof(IStatusEffectUpdateTiming))]
        private ScriptableObject updateTiming;
        public IStatusEffectUpdateTiming UpdateTiming => updateTiming as IStatusEffectUpdateTiming;
        
        //TODO: Create UniqueEffect Instance Count
        [SerializeField] [RequireInterface(typeof(IStatusEffectInstance))]
        private ScriptableObject _statusEffectInstance;
        public IStatusEffectInstance StatusEffectInstance => _statusEffectInstance as IStatusEffectInstance;
        
        

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

        
        public virtual void ApplyUniqueEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardAction in StandardActions)
            {
                logicTree.AddCurrent(standardAction.RegisterStandardAction(hero));
            }
        }

        public virtual void UnapplyUniqueEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardAction in StandardActions)
            {
                logicTree.AddCurrent(standardAction.UnregisterStandardAction(hero));
            }
        }
        
        //TODO: Create IUniqueEffect Component attached to a prefab
        public virtual void RemoveUniqueEffectOnDeath(IHero hero, IHeroStatusEffect statusEffect)
        {
            
            statusEffect.RemoveStatusEffect.RemoveEffect(hero);
        }

      




    }
}
