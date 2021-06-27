using System;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class LoadStatusEffectPreview : MonoBehaviour, ILoadStatusEffectPreview
    {
        private IStatusEffectPreview _statusEffectPreview;

        private void Awake()
        {
            _statusEffectPreview = GetComponent<IStatusEffectPreview>();
        }

        public void LoadVisualValues(IStatusEffectAsset statusEffectAsset )
        {
            _statusEffectPreview.StatusEffectIcon.sprite = statusEffectAsset.Icon;
            _statusEffectPreview.StatusEffectName.text = statusEffectAsset.Name;
            _statusEffectPreview.StatusEffectDescription.text = statusEffectAsset.Description;
        }


    }
}
