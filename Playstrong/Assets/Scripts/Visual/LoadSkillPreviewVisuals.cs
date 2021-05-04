using System;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class LoadSkillPreviewVisuals : MonoBehaviour, ILoadSkillPreviewVisuals
    {
        
        private ISkillPreviewVisual _skillPreviewVisual;

        private void Awake()
        {
            _skillPreviewVisual = GetComponent<ISkillPreviewVisual>();
        }

        public void LoadSkillPreviewVisualsFromAsset(IHeroSkillAsset skillAsset)
        {
            _skillPreviewVisual.PreviewImage.sprite = skillAsset.SkillIcon;
            _skillPreviewVisual.Cooldown.text = skillAsset.Cooldown.ToString();
            _skillPreviewVisual.PreviewName.text = skillAsset.Name;
            _skillPreviewVisual.Description.text = skillAsset.Description;
        }
        
        
    }
}
