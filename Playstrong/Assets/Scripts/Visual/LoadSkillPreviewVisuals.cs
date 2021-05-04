using Interfaces;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class LoadSkillPreviewVisuals : MonoBehaviour, ILoadSkillPreviewVisuals
    {
        [SerializeField]
        [RequireInterface(typeof(ISkillPreviewVisual))]
        private Object _skillPreviewVisual;

        public ISkillPreviewVisual SkillPreviewVisual => _skillPreviewVisual as ISkillPreviewVisual;

        public void LoadSkillPreviewVisualsFromAsset(IHeroSkillAsset skillAsset)
        {
            SkillPreviewVisual.PreviewImage.sprite = skillAsset.SkillIcon;
            SkillPreviewVisual.Cooldown.text = skillAsset.Cooldown.ToString();
            SkillPreviewVisual.PreviewName.text = skillAsset.Name;
            SkillPreviewVisual.Description.text = skillAsset.Description;
        }
        
        
    }
}
