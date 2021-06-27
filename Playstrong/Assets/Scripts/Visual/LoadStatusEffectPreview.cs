using System;
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

        public void LoadVisualValues(Sprite statusEffectIcon, string statusEffectName, string statusEffectDescription )
        {
            _statusEffectPreview.StatusEffectIcon.sprite = statusEffectIcon;
            _statusEffectPreview.StatusEffectName.text = statusEffectName;
            _statusEffectPreview.StatusEffectDescription.text = statusEffectDescription;
        }


    }
}
