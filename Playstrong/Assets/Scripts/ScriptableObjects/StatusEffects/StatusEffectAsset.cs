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

        [Header("Obsolete")]
        [SerializeField] private ScriptableObject _skillactionAsset;
        public IHeroAction SkillActionAsset => _skillactionAsset as IHeroAction;

        [Header("Obsolete")]
        [SerializeField] private ScriptableObject _standardAction;
        public IStandardActionAsset StandardAction => _standardAction as IStandardActionAsset;

        [SerializeField] private List<ScriptableObject> _standardActions;

        private List<IStandardActionAsset> StandardActions
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



        //maximum skill status effect counters
        //Used by stacking skill effects
        [SerializeField] private int maxSkillCounters = 1 ;
        public int MaxSkillCounters => maxSkillCounters;

        public IHero CasterHero { get; set; }

        protected ICoroutineTree LogicTree;
        protected ICoroutineTree VisualTree;
        protected IHero TargetHero;
        
        //For cleanup
        [SerializeField] private float _effectValue;

        public float EffectValue
        {
            get => _effectValue;
            set => _effectValue = value;
        }

        
        public IHeroStatusEffect HeroStatusEffectReference { get; set; }



        protected void InitializeValues(IHero hero)
        {
            LogicTree = hero.CoroutineTreesAsset.MainLogicTree;
            VisualTree = hero.CoroutineTreesAsset.MainVisualTree;
            TargetHero = hero;

        }
        
        public virtual void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardAction in StandardActions)
            {
                
                //TEST
                //standardAction.StartAction(hero,EffectValue);
                
                //TEST
                logicTree.AddCurrent(standardAction.RegisterStandardAction(hero));
            }
        }

        public virtual void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            foreach (var standardAction in StandardActions)
            {
                //TEST
                //standardAction.StartAction(hero,-EffectValue);
                
                logicTree.AddCurrent(standardAction.UnregisterStandardAction(hero));
            }
        }
        
        public virtual void ApplyStackingEffect(IHero hero)
        {
        }
        
        public virtual void UnapplyStackingEffect(IHero hero)
        {
        }
        
        
        
        
        public virtual IEnumerator StartSkillAction()
        {
            LogicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For status effects called by events
        /// </summary>
        /// <param name="hero"></param>
        public virtual void StartEventStatusEffect(IHero hero)
        {
            
        }

        public virtual void RemoveStatusEffect(IHero hero)
        {
            HeroStatusEffectReference.RemoveStatusEffect.RemoveEffect(hero);
        }





    }
}
