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

        public virtual void ApplyStatusEffect()
        {
        }

    }
}
