using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects.StatusEffects
{
    public class StatusEffectAsset : ScriptableObject, IStatusEffect
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [TextArea(1,2)]
        [SerializeField] private string _description;
        public string Description => _description;
            
        
        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;
        
        //TODO: statusEffectType - i.e. Buff or Debuff
        [SerializeField] private ScriptableObject _statusEffectType;
        public IStatusEffectType StatusEffectType => _statusEffectType as IStatusEffectType;

        public virtual void ApplyStatusEffect()
        {
        }

    }
}
