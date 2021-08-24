using System.Collections;
using Interfaces;
using Logic;
using References;
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

        [SerializeField] private ScriptableObject _skillactionAsset;
        public IHeroAction SkillActionAsset => _skillactionAsset as IHeroAction;

        protected ICoroutineTree LogicTree;
        protected ICoroutineTree VisualTree;
        protected IHero Hero;
        
        //TEST
        [SerializeField] private float _effectValue;

        public float EffectValue
        {
            get => _effectValue;
            set => _effectValue = value;
        }

        //TEST END
        
        protected void InitializeValues(IHero hero)
        {
            LogicTree = hero.CoroutineTreesAsset.MainLogicTree;
            VisualTree = hero.CoroutineTreesAsset.MainVisualTree;
            Hero = hero;

        }
        
        public virtual void ApplyStatusEffect(IHero hero)
        {
        }

        public virtual void UnapplyStatusEffect(IHero hero)
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


    }
}
