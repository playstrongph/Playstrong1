using Interfaces;
using Logic;
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
        
        [SerializeField]
        [RequireInterface(typeof(IHeroAction))]
        private ScriptableObject _skillAction;

        public IHeroAction SkillAction => _skillAction as IHeroAction;
        
        protected ICoroutineTree LogicTree;
        protected ICoroutineTree VisualTree;
        protected IHero Hero;
        
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
        
        public virtual void StartTurnStatusEffect(IHero hero)
        {
        }
        
        public virtual void EndTurnStatusEffect(IHero hero)
        {
        }
        
        

    }
}
