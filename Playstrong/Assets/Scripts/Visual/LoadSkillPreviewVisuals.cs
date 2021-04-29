using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadSkillPreviewVisuals : MonoBehaviour, ILoadSkillPreviewVisuals
    {
        private ISkillPreviewVisual _skillPreviewVisual;
        private ISkillAttributes _skillAttributes;

        private void Awake()
        {
            _skillPreviewVisual = GetComponent<ISkillPreviewVisual>();
            _skillAttributes = _skillPreviewVisual.SkillObjectReferences.SkillLogicReferences.SkillAttributes;
        
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
