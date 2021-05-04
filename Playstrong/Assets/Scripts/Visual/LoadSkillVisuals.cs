using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadSkillVisuals : MonoBehaviour, ILoadSkillVisuals
    {
        private ISkillVisualReferences _skillVisualReferences;
        private ISkillAttributes _skillAttributes;

        private void Awake()
        {
            _skillVisualReferences = GetComponent<ISkillVisualReferences>();
            _skillAttributes = _skillVisualReferences.SkillPrefab.SkillLogicReferences.SkillAttributes;
        }

        public void LoadSkillVisualsFromSkillAsset(IHeroSkillAsset heroSkillAsset)
        {
            _skillVisualReferences.SkillGraphic.sprite = heroSkillAsset.SkillIcon;
            _skillVisualReferences.CooldownText.text = _skillAttributes.Cooldown.ToString();
        }
    }
}
