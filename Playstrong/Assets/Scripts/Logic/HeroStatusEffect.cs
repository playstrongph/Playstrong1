using ScriptableObjects.StatusEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class HeroStatusEffect : MonoBehaviour
    {
        [SerializeField]
        private Object _statusEffectAsset;

        public IStatusEffect StatusEffectAsset
        {
            get => _statusEffectAsset as IStatusEffect;
            set => _statusEffectAsset = value as Object;
        }


        [SerializeField] private Image _icon;
        public Image Icon => _icon;

        [SerializeField] private TextMeshProUGUI _buffCounterVisual;
        public TextMeshProUGUI BuffCounterVisual => _buffCounterVisual;
        
        
        
        
    }
}
