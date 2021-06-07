using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects.StatusEffects
{
    public class StatusEffectAsset : ScriptableObject, IStatusEffect
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private string _description;
        public string Description => _description;
            
        
        [SerializeField] private Image _icon;
        public Image Icon => _icon;
        
        //TODO: statusEffectType - i.e. Buff or Debuff

        public virtual void ApplyStatusEffect()
        {
        }

    }
}
